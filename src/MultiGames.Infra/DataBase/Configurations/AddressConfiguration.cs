using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiGames.Domain.Entities;
using Dapper;

namespace MultiGames.Infra.DataBase.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<AddressDomain>
{
    public void Configure(EntityTypeBuilder<AddressDomain> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Street).HasMaxLength(100);
        builder.Property(e => e.StreetNumber).HasMaxLength(50);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Country).HasMaxLength(50);
        builder.Property(e => e.State).HasMaxLength(50);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.TelPhone).HasMaxLength(15);
        builder.Property(e => e.CelPhone).HasMaxLength(15);
        builder.HasMany(e => e.Brothers).WithOne(e => e.Address);
    }
}
