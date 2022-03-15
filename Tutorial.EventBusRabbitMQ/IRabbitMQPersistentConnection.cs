using RabbitMQ.Client;
using System;

namespace Tutorial.EventBusRabbitMQ
{
    //Connection sınıfları IDisposable olmalı
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        bool IsConnected { get; }
        bool TryConnect();
        //RabbitMQ ile gelir
        IModel CreateModel();
    }
}
