using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
