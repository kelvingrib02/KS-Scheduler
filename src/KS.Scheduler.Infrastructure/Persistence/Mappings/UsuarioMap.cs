using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Nome).IsRequired().HasColumnType("varchar(100)");

            builder.Property(j => j.Email).IsRequired().HasColumnType("varchar(50)");

            builder.Property(j => j.Telefone).IsRequired().HasColumnType("varchar(20)");
        }
    }
}