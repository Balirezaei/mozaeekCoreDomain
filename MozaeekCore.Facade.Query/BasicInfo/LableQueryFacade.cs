using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public class LableQueryFacade: ILableQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public LableQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<LableDto> GetLableById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, LableDto>(new FindByKey(id));
        }

        public Task<List<LableDto>> GetAllLables(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ILableQueryFacade
    {
        Task<LableDto> GetLableById(long id);
        Task<List<LableDto>> GetAllLables(PagingContract pagingContract);
    }

}