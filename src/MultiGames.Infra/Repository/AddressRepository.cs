using MultiGames.Application.Repository;
using MultiGames.Domain.Entities;
using MultiGames.Infra.DataBase.Context;
using MultiGames.Infra.Repository.Base;

namespace MultiGames.Infra.Repository;

public class AddressRepository : Repository<AddressDomain>, IAddressRepository
{
    public AddressRepository(MultiGamesContext context) : base(context)
    {
    }
}
