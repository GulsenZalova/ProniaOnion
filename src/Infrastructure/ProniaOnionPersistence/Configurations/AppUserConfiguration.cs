using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
            .Property(u=>u.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");


            builder
            .Property(u => u.Surname)
            .HasColumnType("varchar(100)");
            
        }

       
    }
}