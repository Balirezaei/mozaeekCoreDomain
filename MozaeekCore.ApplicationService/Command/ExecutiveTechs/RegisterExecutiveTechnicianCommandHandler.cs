using MozaeekCore.ApplicationService.Contract.ExecutiveTechs;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using MozaeekCore.Domain.ExecutiveTechs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.ApplicationService.Command.ExecutiveTechs
{
    public class RegisterExecutiveTechnicianCommandHandler : IBaseAsyncCommandHandler<RegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>
    {
        private readonly IExecutiveTechnicianRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public RegisterExecutiveTechnicianCommandHandler(IExecutiveTechnicianRepository repository,IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<RegisterExecutiveTechnicianCommandResult> HandleAsync(RegisterExecutiveTechnicianCommand cmd)
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
