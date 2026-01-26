using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KS.Scheduler.Infrastructure.Persistence
{
    public class KSSchedulerDbContext : DbContext
    {
        public KSSchedulerDbContext(DbContextOptions<KSSchedulerDbContext> options) : base(options)
        {
        }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Partida>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).ValueGeneratedNever();

                e.Property(p => p.ValorTotal).HasColumnType("decimal(18,2)");
                e.Property(p => p.ValorPorPessoa).HasColumnType("decimal(18,2)");

                e.HasMany(p => p.Presencas).WithOne(pr => pr.Partida).HasForeignKey(pr => pr.PartidaId);
            });

            modelBuilder.Entity<Presenca>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Jogador>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).ValueGeneratedNever();
                e.Property(p => p.Telefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Usuario>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).ValueGeneratedNever();
                e.Property(p => p.Telefone).HasMaxLength(20);
                e.Property(p => p.Email).HasMaxLength(150);
                e.Property(p => p.SenhaHash).HasMaxLength(200);
                e.HasIndex(p => p.Email).IsUnique();
            });
        }
    }
}