using MultiGames.Application.Repository;
using MultiGames.Domain.Entities;
using MultiGames.Infra.DataBase.Context;
using MultiGames.Infra.Repository.Base;


namespace MultiGames.Infra.Repository;

public class BrotherRepository : Repository<BrotherDomain>, IBrotherRepository
{
    public BrotherRepository(MultiGamesContext context) : base(context)
    {
    }

}
