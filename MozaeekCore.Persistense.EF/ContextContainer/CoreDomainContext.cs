using Microsoft.EntityFrameworkCore;
using MozaeekCore.Domain;
using MozaeekCore.Domain.BasicInfo;
using MozaeekCore.Domain.ExecutiveTechs;

namespace MozaeekCore.Persistense.EF
{
    public class CoreDomainContext: DbContext
    {
        public CoreDomainContext()
        { }

        public CoreDomainContext(DbContextOptions<CoreDomainContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        
        //entities
        public DbSet<UnProcessedRequest> UnProcessedRequests { get; set; }
        public DbSet<ExecutiveTechnician> ExecutiveTechnicians { get; set; }
        public DbSet<Lable> Lables { get; set; }
        public DbSet<RequestTarget> RequestTargets { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<RequestAct> RequestActs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<RequestOrg> RequestOrgs { get; set; }
    }
}