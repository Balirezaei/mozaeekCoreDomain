using System;
using System.Collections.Generic;
using System.Text;

namespace MozaeekCore.Domain.Contract.IntegrationEvents
{
    public class ExecutiveTechnicianRegistered
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
    }
}
