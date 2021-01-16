using MozaeekCore.ApplicationService.Contract.ExecutiveTechs;
using MozaeekCore.Core.CommandHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozaeekCore.ApplicationService.Command.ExecutiveTechs
{
    public class RegisterExecutiveTechnicianCommandHandler : IBaseCommandHandler<RegisterExecutiveTechnicianCommand, RegisterExecutiveTechnicianCommandResult>
    {
        public RegisterExecutiveTechnicianCommandHandler()
        {

        }
        public RegisterExecutiveTechnicianCommandResult Handle(RegisterExecutiveTechnicianCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
