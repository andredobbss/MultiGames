using Microsoft.AspNetCore.Identity;
using MultiGames.Application.Authorization.UserIdentityDTO;

namespace MultiGames.Application.Authorization.Repository;

public interface IAuthorizationRepository
{
    Task<IdentityResult> Register(UserDto userDTO);
    Task<IdentityUser> Login(UserDto userDTO);
    Task<bool> CheckPasswords(IdentityUser user, UserDto userDTO);
}
