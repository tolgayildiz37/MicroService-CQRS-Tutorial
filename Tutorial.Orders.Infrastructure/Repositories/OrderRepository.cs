using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Orders.Domain.Entities;
using Tutorial.Orders.Domain.Repositories.Base;
using Tutorial.Orders.Infrastructure.Data;
using Tutorial.Orders.Infrastructure.Repositories.Base;

namespace Tutorial.Orders.Infrastructure.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName)
        {
            return await _dbContext.Orders
                            .Where(p => p.SellerUserName.Equals(userName))
                            .ToListAsync();
        }
    }
}
