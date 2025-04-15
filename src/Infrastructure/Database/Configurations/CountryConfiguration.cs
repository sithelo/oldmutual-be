using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()");

        builder.ComplexProperty(
            u => u.Name,
            b => b.Property(e => e.Value)
                .HasColumnName("name"));

        builder.ComplexProperty(
            u => u.Flag,
            b => b.Property(e => e.Value).HasColumnName("flag"));
        
        builder.ComplexProperty(
            u => u.City,
            b => b.Property(e => e.Value).HasColumnName("city"));
        
        //builder.HasIndex(c => c.Name).IsUnique();
        
     
    }
}
