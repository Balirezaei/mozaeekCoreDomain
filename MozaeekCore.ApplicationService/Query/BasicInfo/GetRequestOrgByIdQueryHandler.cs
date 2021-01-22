using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetRequestOrgByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, RequestOrgDto>
    {
        private readonly IGenericRepository<RequestOrg> _repository;

        public GetRequestOrgByIdQueryHandler(IGenericRepository<RequestOrg> repository)
        {
            _repository = repository;
        }
        public async Task<RequestOrgDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            return res.GetRequestOrgDto();
        }
    }
}