using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Rodonaves.Models;

namespace Sistema_Rodonaves.Data.Map
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaboradore>
    {
        public void Configure(EntityTypeBuilder<Colaboradore> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
