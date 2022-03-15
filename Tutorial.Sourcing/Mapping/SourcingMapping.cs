using AutoMapper;
using Tutorial.EventBusRabbitMQ.Events;
using Tutorial.Sourcing.Entities;

namespace Tutorial.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
