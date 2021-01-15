using MozaeekCore.ApplicationService.Contract;

namespace MozaeekCore.Facade.Query
{
    public interface IUnProcessedRequestQueryFacade
    {
        UnProcessedRequestDto GetProcessedRequestById(int id);
    }
}