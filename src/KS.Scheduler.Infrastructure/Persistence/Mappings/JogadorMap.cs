using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class JogadorMap : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Nome).IsRequired().HasColumnType("varchar(100)");

            builder.Property(j => j.Telefone).IsRequired().HasColumnType("varchar(20)");

            builder.HasMany(j => j.Presencas).WithOne(p => p.Jogador).HasForeignKey(p => p.JogadorId);
        }
    }
}