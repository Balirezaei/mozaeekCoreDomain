using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public interface IRequestActQueryFacade
    {
        Task<RequestActDto> GetRequestActById(long id);
        Task<List<RequestActDto>> GetAllRequestActs(PagingContract pagingContract);
    }

    public class RequestActQueryFacade : IRequestActQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public RequestActQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<RequestActDto> GetRequestActById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, RequestActDto>(new FindByKey(id));
        }

        public Task<List<RequestActDto>> GetAllRequestActs(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }
}