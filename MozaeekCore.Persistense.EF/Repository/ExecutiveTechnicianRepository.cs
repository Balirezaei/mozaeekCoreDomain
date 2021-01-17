using Microsoft.EntityFrameworkCore;
using MozaeekCore.Domain.ExecutiveTechs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.Persistense.EF.Repository
{
    public class ExecutiveTechnicianRepository : IExecutiveTechnicianRepository
    {
        private readonly CoreDomainContext _context;

        public ExecutiveTechnicianRepository(CoreDomainContext context)
        {
            _context = context;
        }
        public void Add(ExecutiveTechnician executiveTechnician)
        {
             _context.Add(executiveTechnician);
        }

        public Task<ExecutiveTechnician> Find(int id)
        {
            return _context.ExecutiveTechnicians.SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
