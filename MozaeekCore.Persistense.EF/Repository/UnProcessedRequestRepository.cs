using System.Linq;
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

        public UnProcessedRequest Find(int id)
        {
            return _context.UnProcessedRequests.SingleOrDefault(m => m.Id==id);
        }
    }
}