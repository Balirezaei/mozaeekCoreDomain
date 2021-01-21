using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Command;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandHandler;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class CommandHandlerRegistration
    {
        public static IServiceCollection AddCommandHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseAsyncCommandHandler<CreateUnProcessedRequestCommand, UnProcessedRequestCommandResult>, UnProcessedRequestCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateRegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>, RegisterExecutiveTechnicianCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateLableCommand, CreateLableCommandResult>, CreateLableCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateRequestOrgCommand, CreateRequestOrgCommandResult>, CreateRequestOrgCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateSubjectCommand, CreateSubjectCommandResult>, CreateSubjectCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateRequestActCommand, CreateRequestActCommandResult>, CreateRequestActCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreatePointCommand, CreatePointCommandResult>, CreatePointCommandHandler>();
            services.AddScoped<IBaseAsyncCommandHandler<CreateRequestTargetCommand, CreateRequestTargetCommandResult>, CreateRequestTargetCommandHandler>();

            return services;
        }
    }
}