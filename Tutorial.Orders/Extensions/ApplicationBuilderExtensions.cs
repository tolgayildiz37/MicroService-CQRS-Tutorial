using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tutorial.Orders.Consumers;

namespace Tutorial.Orders.Extensions
{
    // Uygulama ayağa kalktığı andan itibaren dinlemeye başlaması için geliştirildi
    public static class ApplicationBuilderExtensions
    {
        public static EventBusOrderCreateConsumer Listener { get; set; }

        public static IApplicationBuilder UseRabbitMQListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusOrderCreateConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(Stopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void Stopping()
        {
            Listener.Disconnect();
        }
    }
}
