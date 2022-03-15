using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Tutorial.Orders.Infrastructure.Data;

namespace Tutorial.Orders.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    // Context'i generate ediyoruz
                    var orderContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
                    
                    if(orderContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        orderContext.Database.Migrate();
                    }

                    OrderContextSeed.SeedAsync(orderContext).Wait();
                }
                catch (Exception e)
                {

                    throw;
                }

                return host;
            }
        }
    }
}
