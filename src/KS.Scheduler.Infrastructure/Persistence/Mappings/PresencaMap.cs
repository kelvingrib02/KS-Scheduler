using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class PresencaMap : IEntityTypeConfiguration<Presenca>
    {
        public void Configure(EntityTypeBuilder<Presenca> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => new { p.PartidaId, p.JogadorId }).IsUnique();
        }
    }
}