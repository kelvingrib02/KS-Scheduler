using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KS.Scheduler.Infrastructure.Persistence
{
    public class KSSchedulerDbContextFactory : IDesignTimeDbContextFactory<KSSchedulerDbContext>
    {
        public KSSchedulerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KSSchedulerDbContext>();

            optionsBuilder.UseSqlServer("Server=KELVIN-DESKTOP;Database=dbKSScheduler;Trusted_Connection=True;TrustServerCertificate=True;");

            return new KSSchedulerDbContext(optionsBuilder.Options);
        }
    }
}