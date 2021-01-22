using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public interface IRequestOrgQueryFacade
    {
        Task<RequestOrgDto> GetRequestOrgById(long id);
        Task<List<RequestOrgDto>> GetAllRequestOrgs(PagingContract pagingContract);
    }
    public class RequestOrgQueryFacade : IRequestOrgQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public RequestOrgQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<RequestOrgDto> GetRequestOrgById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, RequestOrgDto>(new FindByKey(id));
        }

        public Task<List<RequestOrgDto>> GetAllRequestOrgs(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }
}