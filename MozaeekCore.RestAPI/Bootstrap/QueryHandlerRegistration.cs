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
            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, UnProcessedRequestDto>, GetUnProcessedRequestByIdQueryHandler>();
            services.AddScoped<IUnProcessedRequestQueryFacade, UnProcessedRequestQueryFacade>();

            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, ExecutiveTechnicianDto>, GetExecutiveTechnicianByIdQueryHandler>();
            services.AddScoped<IExecutiveTechnicianQueryFacade, ExecutiveTechnicianQueryFacade>();
            
            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, LableDto>, GetLableByIdQueryHandler>();
            services.AddScoped<ILableQueryFacade, LableQueryFacade>();


            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, PointDto>, GetPointByIdQueryHandler>();
            services.AddScoped<IPointQueryFacade, PointQueryFacade>();

            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, RequestOrgDto>, GetRequestOrgByIdQueryHandler>();
            services.AddScoped<IRequestOrgQueryFacade, RequestOrgQueryFacade>();


            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, RequestActDto>, GetRequestActByIdQueryHandler>();
            services.AddScoped<IRequestActQueryFacade, RequestActQueryFacade>();



            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, RequestTargetDto>, GetRequestTargetByIdQueryHandler>();
            services.AddScoped<IRequestTargetQueryFacade, RequestTargetQueryFacade>();


            services.AddScoped<IBaseAsyncQueryHandler<FindByKey, SubjectDto>, GetSubjectByIdQueryHandler>();
            services.AddScoped<ISubjectQueryFacade, SubjectQueryFacade>();




            return services;
        }
    }
}