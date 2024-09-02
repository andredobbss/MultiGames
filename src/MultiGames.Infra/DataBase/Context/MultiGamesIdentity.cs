using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MultiGames.Infra.DataBase.Context;

public class MultiGamesIdentity : IdentityDbContext
{
    public MultiGamesIdentity(DbContextOptions<MultiGamesIdentity> optinos) : base(optinos)
    {
            
    }
}
