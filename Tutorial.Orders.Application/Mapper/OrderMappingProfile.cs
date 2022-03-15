using AutoMapper;
using Tutorial.Orders.Application.Commands.OrderCreate;
using Tutorial.Orders.Application.Responses;
using Tutorial.Orders.Domain.Entities;

namespace Tutorial.Orders.Application.Mapper
{
    //DependencyInjection.cs içinde create edildi
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderCreateCommand>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
