using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandHandler;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection AddCommandHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseCommandHandler<UnProcessedRequestCommand, UnProcessedRequestCommandResult>, UnProcessedRequestCommandHandler>();

            return services;
        }
    }
}