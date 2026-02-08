using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
             builder.HasKey(x=>new{x.ProductId,x.ColorId});
        }
    }
}