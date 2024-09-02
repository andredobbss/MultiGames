using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiGames.Domain.Entities;
using System.Reflection.Emit;

namespace MultiGames.Infra.DataBase.Configurations;

public class BrotherConfiguration : IEntityTypeConfiguration<BrotherDomain>
{
    public void Configure(EntityTypeBuilder<BrotherDomain> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Cpf).HasMaxLength(14);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.HasOne(a => a.Address).WithMany(a => a.Brothers);
        builder.HasMany(e => e.Games).WithOne(e => e.Brother);
       // builder.HasData(
       //    new BrotherDomain("Teste1", "111.111.111-01", "teste01@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime()),
       //    new BrotherDomain("Teste2", "222.222.222-02", "teste02@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime()),
       //    new BrotherDomain("Teste3", "333.333.333-03", "teste03@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime()),
       //    new BrotherDomain("Teste4", "444.444.444-04", "teste04@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime()),
       //    new BrotherDomain("Teste5", "555.555.555-05", "teste05@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime()),
       //    new BrotherDomain("Teste6", "666.666.666-06", "teste06@teste.com", Guid.NewGuid(), DateTimeOffset.Now.ToUniversalTime())
       //);
    }
}
