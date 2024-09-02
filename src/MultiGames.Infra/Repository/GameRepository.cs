using MultiGames.Application.Repository;
using MultiGames.Domain.Entities;
using MultiGames.Infra.DataBase.Context;
using MultiGames.Infra.Repository.Base;
using System.Data.Common;

namespace MultiGames.Infra.Repository;

public class GameRepository : Repository<GameDomain>, IGameRepository
{
    public GameRepository(MultiGamesContext context) : base(context)
    {
    }
}
