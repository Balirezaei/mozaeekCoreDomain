using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.Facade.Query
{
    public class ExecutiveTechnicianQueryFacade: IExecutiveTechnicianQueryFacade
    {
        private readonly IQueryProcessor queryProcessor;

        public ExecutiveTechnicianQueryFacade(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }
        public Task<ExecutiveTechnicianDto> GetExecutiveTechnicianById(int id)
        {
            return queryProcessor.ProcessAsync<FindByKey, ExecutiveTechnicianDto>(new FindByKey(id));
        }
    }
}
