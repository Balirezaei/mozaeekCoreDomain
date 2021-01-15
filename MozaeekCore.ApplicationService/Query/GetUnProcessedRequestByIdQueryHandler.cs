using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetUnProcessedRequestByIdQueryHandler : IBaseQueryHandler<FindByKey, UnProcessedRequestDto>
    {
        private readonly IUnProcessedRequestRepository _unProcessedRequestRepository;

        public GetUnProcessedRequestByIdQueryHandler(IUnProcessedRequestRepository unProcessedRequestRepository)
        {
            _unProcessedRequestRepository = unProcessedRequestRepository;
        }

        public UnProcessedRequestDto Handle(FindByKey query)
        {
            var res = _unProcessedRequestRepository.Find(query.Id);
            return new UnProcessedRequestDto()
            {
                Title = res.Title,
                Summery = res.Summery,
                IsProcessed = res.IsProcessed,
                Id = res.Id
            };
        }
    }
}