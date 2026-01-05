using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace KS.Scheduler.Infrastructure.Persistence
{
    public class KSSchedulerDbContext : DbContext
    {
        public KSSchedulerDbContext(DbContextOptions<KSSchedulerDbContext> options) : base(options) { }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Presenca> Presencas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}