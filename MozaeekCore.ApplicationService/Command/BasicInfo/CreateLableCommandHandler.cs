using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateLableCommandHandler : IBaseAsyncCommandHandler<CreateLableCommand, CreateLableCommandResult>
    {

        private readonly IGenericRepository<Lable> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLableCommandHandler(IGenericRepository<Lable> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateLableCommandResult> HandleAsync(CreateLableCommand cmd)
        {
            var lable = new Lable(cmd.Title, cmd.ParentId);
            _repository.Add(lable);
            await _unitOfWork.CommitAsync();
            return new CreateLableCommandResult()
            {
                Id = lable.Id,
                ParentId = lable.ParentId,
                Title = lable.Title
            };
        }
    }
}