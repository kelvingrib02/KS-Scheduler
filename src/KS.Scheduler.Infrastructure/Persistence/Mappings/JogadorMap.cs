using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.ToTable("Jogadores");

            builder.HasKey(j => j.Id);

            builder.Property(j => j.Id).ValueGeneratedNever();

            builder.Property(j => j.Posicao).HasColumnType("varchar(50)").IsRequired();

            builder.Property(j => j.NivelHabilidade).IsRequired();

            builder.Property(j => j.UsuarioId).IsRequired();

            builder.HasOne(j => j.Usuario).WithOne().HasForeignKey<Jogador>(j => j.UsuarioId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(j => j.Presencas).WithOne(p => p.Jogador).HasForeignKey(p => p.JogadorId);
        }
    }
}