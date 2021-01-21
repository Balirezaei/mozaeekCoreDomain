using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.CommandHandler;
using System.Threading.Tasks;
using MozaeekCore.Core;
using MozaeekCore.Domain;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.ApplicationService.Command
{
    public class CreatePointCommandHandler : IBaseAsyncCommandHandler<CreatePointCommand, CreatePointCommandResult>
    {
        private readonly IGenericRepository<Point> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePointCommandHandler(IGenericRepository<Point> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreatePointCommandResult> HandleAsync(CreatePointCommand cmd)
        {
            var Point = new Point(cmd.Title, cmd.ParentId);
            _repository.Add(Point);
            await _unitOfWork.CommitAsync();
            return new CreatePointCommandResult()
            {
                Id = Point.Id,
                ParentId = Point.ParentId,
                Title = Point.Title
            };
        }
    }
}