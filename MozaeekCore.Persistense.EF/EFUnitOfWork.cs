using MozaeekCore.Core;

namespace MozaeekCore.Persistense.EF
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private readonly CoreDomainContext _context;

        public EFUnitOfWork(CoreDomainContext context)
        {
            _context = context;
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        
    }
}