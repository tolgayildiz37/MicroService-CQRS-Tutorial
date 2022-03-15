using MediatR;
using System.Collections.Generic;
using Tutorial.Orders.Application.Responses;

namespace Tutorial.Orders.Application.Queries
{
    public class GetOdersBySellersUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string Username { get; set; }

        public GetOdersBySellersUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
