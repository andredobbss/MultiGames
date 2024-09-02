using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiGames.Domain.Entities;

namespace MultiGames.Infra.DataBase.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<GameDomain>
{
    public void Configure(EntityTypeBuilder<GameDomain> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).HasMaxLength(50);
        builder.Property(e => e.VersionEdition).HasMaxLength(15);
        builder.Property(e => e.Status).HasMaxLength(15);
        builder.HasOne(e => e.Brother).WithMany(e => e.Games);
    }
}
