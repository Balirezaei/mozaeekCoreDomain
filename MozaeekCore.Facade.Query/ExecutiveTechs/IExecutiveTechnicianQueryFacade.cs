using System.Threading.Tasks;
using MozaeekCore.ApplicationService.Contract;

namespace MozaeekCore.Facade.Query.ExecutiveTechs
{
   public interface IExecutiveTechnicianQueryFacade
    {
        Task<ExecutiveTechnicianDto> GetExecutiveTechnicianById(int id);
    }
}
