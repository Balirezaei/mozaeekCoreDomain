using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.Messaging.RabbitMQ;
using System.Reflection;

namespace Mozaeek.ReadApi.Extensions
{
    public static class MassTransitExtensions
    {
        public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var massTransitSettingSection = configuration.GetSection("MassTransitConfig");
            var massTransitConfig = massTransitSettingSection.Get<MassTransitConfig>();

            services.AddMassTransit(x =>
            {
                x.AddConsumers(Assembly.GetExecutingAssembly());
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                    cfg.Host(massTransitConfig.Host, massTransitConfig.VirtualHost,
                        h =>
                        {
                            h.Username(massTransitConfig.Username);
                            h.Password(massTransitConfig.Password);
                        }
                    );
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
