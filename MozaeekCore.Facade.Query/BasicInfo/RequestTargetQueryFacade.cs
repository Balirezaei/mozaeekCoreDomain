using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public interface IRequestTargetQueryFacade
    {
        Task<RequestTargetDto> GetRequestTargetById(long id);
        Task<List<RequestTargetDto>> GetAllRequestTargets(PagingContract pagingContract);
    }
    public class RequestTargetQueryFacade : IRequestTargetQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public RequestTargetQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<RequestTargetDto> GetRequestTargetById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, RequestTargetDto>(new FindByKey(id));
        }

        public Task<List<RequestTargetDto>> GetAllRequestTargets(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }
}