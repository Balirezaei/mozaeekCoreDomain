using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.CommandBus
{
    public interface ICommandBus
    {
        TResult Dispatch<T, TResult>(T command) where T : Command;
    }
}