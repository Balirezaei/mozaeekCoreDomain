﻿using Microsoft.Extensions.DependencyInjection;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandBus;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Domain.ExecutiveTechs;
using MozaeekCore.LogManagement;
using MozaeekCore.Persistense.EF;
using MozaeekCore.Persistense.EF.Repository;

namespace MozaeekCore.RestAPI.Bootstrap
{
    public static class FrameworkRegistration
    {
        public static IServiceCollection AddFrameworkServices(this IServiceCollection services)
        {
            //AutoMapper.Mapper.Initialize(cfg =>
            //    {
 
            //    }
            //);
            //services.AddAutoMapper();


            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped( typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnProcessedRequestRepository, UnProcessedRequestRepository>();
            services.AddScoped<IExecutiveTechnicianRepository, ExecutiveTechnicianRepository>();
            // services.AddScoped<IUnProcessedRequestQueryFacade, UnProcessedRequestQueryFacade>();
            services.AddScoped<IErrorHandling, LogErrorHandle>();
            services.AddScoped<ILogManagement, DoLogManagement>();
            services.AddScoped(typeof(LoggingHandlerDecorator<,>));
            services.AddScoped(typeof(CatchErrorCommandHandlerDecorator<,>));
            services.AddScoped(typeof(AuthorizeCommandHandlerDecorator<,>));
            services.AddScoped(typeof(AuthorizeCommandAsyncHandlerDecorator<,>));

            return services;
        }
    }
}