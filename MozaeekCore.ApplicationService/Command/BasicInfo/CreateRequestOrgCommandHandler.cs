using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateRequestOrgCommandHandler : IBaseAsyncCommandHandler<CreateRequestOrgCommand, CreateRequestOrgCommandResult>
    {

        private readonly IGenericRepository<RequestOrg> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRequestOrgCommandHandler(IGenericRepository<RequestOrg> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateRequestOrgCommandResult> HandleAsync(CreateRequestOrgCommand cmd)
        {
            var RequestOrg = new RequestOrg(cmd.Title,cmd.ParentId);
            _repository.Add(RequestOrg);
            await _unitOfWork.CommitAsync();
            return new CreateRequestOrgCommandResult()
            {
                Id = RequestOrg.Id,
                Title = RequestOrg.Title
            };
        }
    }
}