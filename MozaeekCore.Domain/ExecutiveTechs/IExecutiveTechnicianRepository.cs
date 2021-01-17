using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.Domain.ExecutiveTechs
{
    public interface IExecutiveTechnicianRepository
    {
        void Add(ExecutiveTechnician executiveTechnician);
        Task<ExecutiveTechnician> Find(int id);
    }
}
