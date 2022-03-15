using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Tutorial.EventBusRabbitMQ;
using Tutorial.EventBusRabbitMQ.Core;
using Tutorial.EventBusRabbitMQ.Events;
using Tutorial.Orders.Application.Commands.OrderCreate;

namespace Tutorial.Orders.Consumers
{
    public class EventBusOrderCreateConsumer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventBusOrderCreateConsumer(IRabbitMQPersistentConnection persistentConnection, IMediator mediator, IMapper mapper)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Consume()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            // Queue'yu yönetmemizi sağlar.
            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(
                queue: EventBusConstants.OrderCreateQueue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ReceivedEvent;

            channel.BasicConsume(
                queue: EventBusConstants.OrderCreateQueue,
                autoAck: true,
                consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            //e.Body.Span ile mesaja ulaşıyoruz
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<OrderCreateEvent>(message);

            // OrderCreateEvent ile OrderCreateCommand birbirine map edildi, bunun için bir Profile açmamız lazım
            // Mediator aracılığı ile orderCreateHandler a göndereceğiz, bunun için command nesnesine ihtiyaç var
            if(e.RoutingKey == EventBusConstants.OrderCreateQueue)
            {
                var command = _mapper.Map<OrderCreateCommand>(@event);

                command.CreatedAt = DateTime.Now;
                command.TotalPrice = @event.Quantity * @event.Price;
                command.UnitPrice = @event.Price;

                var result = await _mediator.Send(command);
            }
        }

        public void Disconnect()
        {
            _persistentConnection.Dispose();
        }
    }
}
