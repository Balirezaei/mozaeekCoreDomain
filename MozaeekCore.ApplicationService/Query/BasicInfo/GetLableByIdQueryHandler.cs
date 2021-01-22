using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetLableByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, LableDto>
    {
        private readonly IGenericRepository<Lable> _repository;

        public GetLableByIdQueryHandler(IGenericRepository<Lable> repository)
        {
            _repository = repository;
        }
        public async Task<LableDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            return res.GetLableDto();
        }
    }
}