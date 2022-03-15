using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tutorial.Orders.Domain.Repositories.Base;
using Tutorial.Orders.Infrastructure.Data;
using Tutorial.Orders.Infrastructure.Repositories;
using Tutorial.Orders.Infrastructure.Repositories.Base;

namespace Tutorial.Orders.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region InMemoryDb Context
            //services.AddDbContext<OrderContext>(options => options.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            //    ServiceLifetime.Singleton,
            //    ServiceLifetime.Singleton); 
            #endregion

            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("OrderConnection"),
                    b => b.MigrationsAssembly(typeof(OrderContext).Assembly.FullName)),
                ServiceLifetime.Singleton
            );

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
