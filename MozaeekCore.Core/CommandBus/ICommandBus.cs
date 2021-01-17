using MozaeekCore.Core.Base;
using System.Threading.Tasks;

namespace MozaeekCore.Core.CommandBus
{
    public interface ICommandBus
    {
        TResult Dispatch<T, TResult>(T command) where T : Command;
        Task<TResult> DispatchAsync<T, TResult>(T command) where T : Command;
    }
}