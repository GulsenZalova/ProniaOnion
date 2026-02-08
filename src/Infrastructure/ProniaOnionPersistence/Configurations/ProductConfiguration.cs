using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
             builder
            .Property(p=>p.Name)
            .IsRequired()
            .HasMaxLength(10);


           builder
            .Property(p=>p.Price)
            .IsRequired()
            .HasColumnType("decimal(6,2)");


            builder
            .Property(p=>p.SKU)
            .HasColumnType("char(10)");
        }
    }
}
    
//set as startup project