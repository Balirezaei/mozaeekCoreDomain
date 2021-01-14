namespace MozaeekCore.Domain
{
    public interface IUnProcessedRequestRepository
    {
        void Add(UnProcessedRequest unProcessedRequest);
    }
}