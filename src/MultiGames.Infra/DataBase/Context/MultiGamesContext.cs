using Microsoft.EntityFrameworkCore;
using MultiGames.Domain.Entities;
using MultiGames.Infra.DataBase.Configurations;
using Dapper;

namespace MultiGames.Infra.DataBase.Context;

public class MultiGamesContext : DbContext
{
   
    public MultiGamesContext(DbContextOptions<MultiGamesContext> options) : base(options)
    {
    }

    public DbSet<AddressDomain> Adresses { get; set; }
    public DbSet<BrotherDomain> Brothers { get; set; }
    public DbSet<GameDomain> Games { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrotherConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);

    //    optionsBuilder.LogTo(, Microsoft.Extensions.Logging.LogLevel.Information);
    //}

    private string Inserts()
    {
        string insert =
            "insert into adsfadfdasfsad";



        return insert;
    }
}
