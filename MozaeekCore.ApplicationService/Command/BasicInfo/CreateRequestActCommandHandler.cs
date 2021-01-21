using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateRequestActCommandHandler : IBaseAsyncCommandHandler<CreateRequestActCommand, CreateRequestActCommandResult>
    {

        private readonly IGenericRepository<RequestAct> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRequestActCommandHandler(IGenericRepository<RequestAct> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateRequestActCommandResult> HandleAsync(CreateRequestActCommand cmd)
        {
            var RequestAct = new RequestAct(cmd.Title);
            _repository.Add(RequestAct);
            await _unitOfWork.CommitAsync();
            return new CreateRequestActCommandResult()
            {
                Id = RequestAct.Id,
                Title = RequestAct.Title
            };
        }
    }
}