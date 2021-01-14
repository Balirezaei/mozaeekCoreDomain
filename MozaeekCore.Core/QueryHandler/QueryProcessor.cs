﻿using System;

namespace MozaeekCore.Core.QueryHandler
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider services;

        public QueryProcessor(IServiceProvider services)
        {
            this.services = services;
        }

        public TResult Process<TQuery, TResult>(TQuery query)
        {
            var handler = (IBaseQueryHandler<TQuery, TResult>)services.GetService(typeof(IBaseQueryHandler<TQuery, TResult>));
            return handler.Handle(query);
        }

        public bool Check<TQuery, TResult>(TQuery query)
        {
            var handler = (IBaseQueryHandler<TQuery, TResult>)services.GetService(typeof(IBaseQueryHandler<TQuery, TResult>));
            return Convert.ToBoolean(handler);
        }
    }
}