using Microsoft.EntityFrameworkCore;
using Tutorial.Orders.Domain.Entities;

namespace Tutorial.Orders.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
