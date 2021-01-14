namespace MozaeekCore.Core.QueryHandler
{
    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery command);
        bool Check<TQuery, TResult>(TQuery query);
    }
}