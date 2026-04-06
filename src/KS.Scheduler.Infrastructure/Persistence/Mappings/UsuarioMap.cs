using KS.Scheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KS.Scheduler.Infrastructure.Persistence.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedNever();

            builder.Property(u => u.Nome).IsRequired().HasColumnType("varchar(100)");

            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(150)");

            builder.Property(u => u.Telefone).HasColumnType("varchar(20)");

            builder.Property(u => u.SenhaHash).IsRequired().HasColumnType("varchar(200)");

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}