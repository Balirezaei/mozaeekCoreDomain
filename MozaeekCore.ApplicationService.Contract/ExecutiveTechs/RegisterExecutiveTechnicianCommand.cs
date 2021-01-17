using MozaeekCore.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozaeekCore.ApplicationService.Contract.ExecutiveTechs
{
    public class RegisterExecutiveTechnicianCommand: Command
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
