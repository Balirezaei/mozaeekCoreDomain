using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.CommandHandler
{
    public interface IBaseCommandHandler<T, TResult> where T : Command
    {
        TResult Handle(T cmd);
    }
}