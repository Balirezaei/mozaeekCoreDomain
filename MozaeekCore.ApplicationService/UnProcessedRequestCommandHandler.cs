using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain;

namespace MozaeekCore.ApplicationService
{
    public class UnProcessedRequestCommandHandler : IBaseCommandHandler<UnProcessedRequestCommand, UnProcessedRequestCommandResult>
    {

        private readonly IUnProcessedRequestRepository _unProcessedRequestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UnProcessedRequestCommandHandler(IUnProcessedRequestRepository unProcessedRequestRepository, IUnitOfWork unitOfWork)
        {
            _unProcessedRequestRepository = unProcessedRequestRepository;
            _unitOfWork = unitOfWork;
        }
        public UnProcessedRequestCommandResult Handle(UnProcessedRequestCommand cmd)
        {
            var unProcessedRequest = new UnProcessedRequest(cmd.Title, cmd.Summery);
            _unProcessedRequestRepository.Add(unProcessedRequest);
            _unitOfWork.Commit();
            return new UnProcessedRequestCommandResult()
            {
                Id = unProcessedRequest.Id
            };

        }
    }
}