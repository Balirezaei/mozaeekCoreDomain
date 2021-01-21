using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.ApplicationService.Query;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Facade.Query;
using MozaeekCore.Facade.Query.ExecutiveTechs;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class QueryHandlerRegistration
    {
        public static IServiceCollection AddQueryHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, UnProcessedRequestDto>, GetUnProcessedRequestByIdQueryHandler>();
            services.AddScoped<IUnProcessedRequestQueryFacade, UnProcessedRequestQueryFacade>();

            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, ExecutiveTechnicianDto>, GetExecutiveTechnicianByIdQueryHandler>();
            services.AddScoped<IExecutiveTechnicianQueryFacade, ExecutiveTechnicianQueryFacade>();

            return services;
        }
    }
}