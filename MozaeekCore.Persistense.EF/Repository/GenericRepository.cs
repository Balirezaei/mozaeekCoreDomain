using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.BasicInfo.Repository;

namespace MozaeekCore.Persistense.EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasicInfo
    {
        private readonly CoreDomainContext _context;

        public GenericRepository(CoreDomainContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task<T> Find(long id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}