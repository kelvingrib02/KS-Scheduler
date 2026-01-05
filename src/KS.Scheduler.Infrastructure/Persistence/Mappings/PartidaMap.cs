using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Local).IsRequired().HasColumnType("varchar(200)");

            builder.HasMany(p => p.Presencas).WithOne(pr => pr.Partida).HasForeignKey(pr => pr.PartidaId);
        }
    }
}