using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetSubjectByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, SubjectDto>
    {
        private readonly IGenericRepository<Subject> _repository;

        public GetSubjectByIdQueryHandler(IGenericRepository<Subject> repository)
        {
            _repository = repository;
        }
        public async Task<SubjectDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            return res.GetSubjectDto();
        }
    }
}