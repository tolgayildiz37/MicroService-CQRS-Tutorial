﻿using System;

namespace Tutorial.EventBusRabbitMQ.Events.Abstract
{
    public abstract class IEvent
    {
        public Guid RequestId { get; private init; }
        public DateTime CreationDate { get; private init; }

        public IEvent()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
