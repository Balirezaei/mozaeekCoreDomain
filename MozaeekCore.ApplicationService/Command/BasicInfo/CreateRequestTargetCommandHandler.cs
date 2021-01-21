using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateRequestTargetCommandHandler : IBaseAsyncCommandHandler<CreateRequestTargetCommand, CreateRequestTargetCommandResult>
    {

        private readonly IGenericRepository<RequestTarget> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRequestTargetCommandHandler(IGenericRepository<RequestTarget> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateRequestTargetCommandResult> HandleAsync(CreateRequestTargetCommand cmd)
        {
            var RequestTarget = new RequestTarget(cmd.Title);
            _repository.Add(RequestTarget);
            await _unitOfWork.CommitAsync();
            return new CreateRequestTargetCommandResult()
            {
                Id = RequestTarget.Id,
                Title = RequestTarget.Title
            };
        }
    }
}