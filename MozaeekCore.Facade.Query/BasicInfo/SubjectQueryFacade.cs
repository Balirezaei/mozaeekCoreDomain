using System.Collections.Generic;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;

namespace MozaeekCore.Facade.Query
{
    public interface ISubjectQueryFacade
    {
        Task<SubjectDto> GetSubjectById(long id);
        Task<List<SubjectDto>> GetAllSubjects(PagingContract pagingContract);
    }
    public class SubjectQueryFacade : ISubjectQueryFacade
    {
        private readonly IQueryProcessor _queryProcessor;

        public SubjectQueryFacade(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public Task<SubjectDto> GetSubjectById(long id)
        {
            return _queryProcessor.ProcessAsync<FindByKey, SubjectDto>(new FindByKey(id));
        }

        public Task<List<SubjectDto>> GetAllSubjects(PagingContract pagingContract)
        {
            throw new System.NotImplementedException();
        }
    }
}