using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.ExecutiveTechs;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;

namespace MozaeekCore.ApplicationService.Command
{
    public class RegisterExecutiveTechnicianCommandHandler : IBaseAsyncCommandHandler<CreateRegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>
    {
        private readonly IExecutiveTechnicianRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public RegisterExecutiveTechnicianCommandHandler(IExecutiveTechnicianRepository repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<RegisterExecutiveTechnicianCommandResult> HandleAsync(CreateRegisterExecutiveTechnicianCommand cmd)
        {
            var executiveTechnician = new ExecutiveTechnician(cmd.FirstName, cmd.LastName,cmd.NationalCode);
            repository.Add(executiveTechnician);
            await unitOfWork.CommitAsync();

            return new RegisterExecutiveTechnicianCommandResult()
            {
                Id = executiveTechnician.Id
            };
        }
    }
}
