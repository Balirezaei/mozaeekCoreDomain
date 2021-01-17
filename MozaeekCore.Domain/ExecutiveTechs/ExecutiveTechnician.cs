using MozaeekCore.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MozaeekCore.Domain.ExecutiveTechs
{
    public class ExecutiveTechnician: AggregateRootBase
    {
        protected ExecutiveTechnician()
        {

        }
        public ExecutiveTechnician(string firstName,string lastName,string nationalCode)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NationalCode = nationalCode;
            CreateDateTime = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CreateDateTime { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }

    }
}
