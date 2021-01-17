using MozaeekCore.ApplicationService.Contract.ExecutiveTechs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.Facade.Query.ExecutiveTechs
{
   public interface IExecutiveTechnicianQueryFacade
    {
        Task<ExecutiveTechnicianDto> GetExecutiveTechnicianById(int id);
    }
}
