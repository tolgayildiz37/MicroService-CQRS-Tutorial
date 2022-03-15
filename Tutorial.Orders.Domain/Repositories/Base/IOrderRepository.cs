using System.Collections.Generic;
using System.Threading.Tasks;
using Tutorial.Orders.Domain.Entities;

namespace Tutorial.Orders.Domain.Repositories.Base
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName);
    }
}
