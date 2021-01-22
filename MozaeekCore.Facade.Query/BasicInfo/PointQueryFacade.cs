using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public interface IPointQueryFacade
    {
        Task<PointDto> GetPointById(long id);
        Task<List<PointDto>> GetAllPoints(PagingContract pagingContract);
    }
    public class PointQueryFacade : IPointQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public PointQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<PointDto> GetPointById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, PointDto>(new FindByKey(id));
        }

        public Task<List<PointDto>> GetAllPoints(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }
    
}