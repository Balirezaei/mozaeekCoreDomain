using MozaeekCore.Domain;

namespace MozaeekCore.Persistense.EF.Repository
{
    public class UnProcessedRequestRepository: IUnProcessedRequestRepository
    {
        private readonly CoreDomainContext _context;

        public UnProcessedRequestRepository(CoreDomainContext context)
        {
            _context = context;
        }
        public void Add(UnProcessedRequest unProcessedRequest)
        {
            _context.UnProcessedRequests.Add(unProcessedRequest);
        }
    }
}