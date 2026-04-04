using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KS.Scheduler.Infrastructure.Persistence
{
    public class KSSchedulerDbContext : DbContext
    {
        public KSSchedulerDbContext(DbContextOptions<KSSchedulerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KSSchedulerDbContext).Assembly);
        }
    }
}