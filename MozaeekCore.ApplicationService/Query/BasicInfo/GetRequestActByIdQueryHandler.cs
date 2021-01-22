using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetRequestActByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, RequestActDto>
    {
        private readonly IGenericRepository<RequestAct> _repository;

        public GetRequestActByIdQueryHandler(IGenericRepository<RequestAct> repository)
        {
            _repository = repository;
        }
        public async Task<RequestActDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            return res.GetRequestActDto();
        }
    }
}