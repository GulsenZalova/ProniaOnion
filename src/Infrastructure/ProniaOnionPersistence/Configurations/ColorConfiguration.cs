using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
            .Property(c=>c.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");


            builder
            .HasIndex(c => c.Name)
            .IsUnique();
        }

       
    }
}