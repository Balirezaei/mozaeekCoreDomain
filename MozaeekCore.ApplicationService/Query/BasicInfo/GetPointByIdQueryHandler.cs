using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;
using MozaeekCore.Mapper;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetPointByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, PointDto>
    {
        private readonly IGenericRepository<Point> _repository;

        public GetPointByIdQueryHandler(IGenericRepository<Point> repository)
        {
            _repository = repository;
        }
        public async Task<PointDto> HandleAsync(FindByKey query)
        {
            var res = await _repository.Find(query.Id);
            return res.GetPointDto();
        }
    }
}