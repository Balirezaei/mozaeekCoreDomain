using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Command.ExecutiveTechs;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.ApplicationService.Contract.ExecutiveTechs;
using MozaeekCore.Core.CommandHandler;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection AddCommandHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseCommandHandler<UnProcessedRequestCommand, UnProcessedRequestCommandResult>, UnProcessedRequestCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<RegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>, RegisterExecutiveTechnicianCommandHandler>();

            return services;
        }
    }
}