using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.ExecutiveTechs;
using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.MessageBus;
using MozaeekCore.Domain.Contract.IntegrationEvents;

namespace MozaeekCore.ApplicationService.Command
{
    public class RegisterExecutiveTechnicianCommandHandler : IBaseAsyncCommandHandler<CreateRegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>
    {
        private readonly IExecutiveTechnicianRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessagePublisher publisher;

        public RegisterExecutiveTechnicianCommandHandler(IExecutiveTechnicianRepository repository,
                                                         IUnitOfWork unitOfWork,
                                                         IMessagePublisher publisher)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.publisher = publisher;
        }

        public async Task<RegisterExecutiveTechnicianCommandResult> HandleAsync(CreateRegisterExecutiveTechnicianCommand cmd)
        {
            var executiveTechnician = new ExecutiveTechnician(cmd.FirstName, cmd.LastName,cmd.NationalCode);
            repository.Add(executiveTechnician);
            await unitOfWork.CommitAsync();

            await publisher.PublishAsync(new ExecutiveTechnicianRegistered()
            {
                Id = executiveTechnician.Id,
                FirstName=executiveTechnician.FirstName,
                LastName=executiveTechnician.LastName,
                NationalCode=executiveTechnician.NationalCode,
                CreateDateTime=executiveTechnician.CreateDateTime
            });

            return new RegisterExecutiveTechnicianCommandResult()
            {
                Id = executiveTechnician.Id
            };
        }
    }
}
