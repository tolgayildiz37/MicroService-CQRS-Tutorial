using AutoMapper;
using Tutorial.EventBusRabbitMQ.Events;
using Tutorial.Orders.Application.Commands.OrderCreate;

namespace Tutorial.Orders.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            //ReverseMap ile, tersine mapping de yapabileceğimizi söylüyoruz
            CreateMap<OrderCreateEvent, OrderCreateCommand>().ReverseMap();
        }
    }
}
