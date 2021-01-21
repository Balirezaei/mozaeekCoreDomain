using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreateSubjectCommandHandler : IBaseAsyncCommandHandler<CreateSubjectCommand, CreateSubjectCommandResult>
    {
        private readonly IGenericRepository<Subject> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSubjectCommandHandler(IGenericRepository<Subject> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateSubjectCommandResult> HandleAsync(CreateSubjectCommand cmd)
        {
            var Subject = new Subject(cmd.Title, cmd.ParentId);
            _repository.Add(Subject);
            await _unitOfWork.CommitAsync();
            return new CreateSubjectCommandResult()
            {
                Id = Subject.Id,
                ParentId = Subject.ParentId,
                Title = Subject.Title
            };
        }
    }
}