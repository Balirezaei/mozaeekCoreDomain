using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.ApplicationService;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.ApplicationService.Query;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Facade.Query;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class QueryHandlerRegistration
    {
        public static IServiceCollection AddQueryHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseQueryHandler<FindByKey, UnProcessedRequestDto>, GetUnProcessedRequestByIdQueryHandler>();
            services.AddScoped<IUnProcessedRequestQueryFacade, UnProcessedRequestQueryFacade>();
            
            return services;
        }
    }
}