using Microsoft.Extensions.Configuration;
using MultiGames.Application.Authentication.TokenDTO;
using MultiGames.Application.Authorization.UserIdentityDTO;

namespace MultiGames.Application.Authentication.Repository;

public interface IAuthenticationRepository
{
    UserTokenDto GenerateToken(UserDto userDto, IConfiguration configuration);
}
