using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Net.Sockets;
using System.Text;
using Tutorial.EventBusRabbitMQ.Events.Abstract;

namespace Tutorial.EventBusRabbitMQ.Producers
{
    // Mesajı yayınlamak için kullanıyoruz
    public class EventBusRabbitMQProducer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly ILogger<EventBusRabbitMQProducer> _logger;
        private readonly int _retryCount;

        public EventBusRabbitMQProducer(IRabbitMQPersistentConnection persistentConnection,
            ILogger<EventBusRabbitMQProducer> logger,
            int retryCount = 5)
        {
            _persistentConnection = persistentConnection;
            _logger = logger;
            _retryCount = retryCount;
        }

        // event ismi default tanımlı olduğu için @event olarak yazdık
        // derleyicide default olarak event isminde bir property bulunuyor
        public void Publish(string queueName, IEvent @event)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            // event'ı publish etmek için gerekli policy bağlantı şartlarını tanımlıyoruz
            // DefaultRabbitMQPersistenConnection içerisinde de bulunuyor
            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                                    .Or<SocketException>()
                                    .WaitAndRetry(_retryCount,
                                                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                                                    (ex, time) =>
                                                    {
                                                        _logger.LogWarning(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", @event.RequestId, $"{time.TotalSeconds:n1}", ex.ToString());
                                                    });

            // işimiz bitince dispose olmasını istediğimiz için using içerisinde yazdık
            using (var channel = _persistentConnection.CreateModel())
            {
                // kanal üzeriden queue deklare ettik
                channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                // event önce json'a dönüştürüldü
                var message = JsonConvert.SerializeObject(@event);
                // json veri binary'e çevriliyor
                var body = Encoding.UTF8.GetBytes(message);

                // bağlantı kurma koşulları belirlendikten sonra policy çalıştırılıyor
                policy.Execute(() =>
                {
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.DeliveryMode = 2;

                    channel.ConfirmSelect();
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queueName,
                        mandatory: true,
                        basicProperties: properties,
                        body: body
                        );
                    channel.WaitForConfirmsOrDie();

                    channel.BasicAcks += (sender, eventArgs) => {
                        Console.WriteLine("Sent RabbitMQ");
                    }; 
                });
            }
        }
    }
}
