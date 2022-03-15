using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Tutorial.Orders.Extensions;

namespace Tutorial.Orders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Extension.MigrationManager
            CreateHostBuilder(args).Build()
                                   .MigrateDatabase()
                                   .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
