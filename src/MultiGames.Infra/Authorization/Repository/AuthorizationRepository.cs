using Microsoft.AspNetCore.Identity;
using MultiGames.Application.Authorization.Repository;
using MultiGames.Application.Authorization.UserIdentityDTO;

namespace MultiGames.Infra.Authorization.Repository;

public class AuthorizationRepository : IAuthorizationRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthorizationRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser> Login(UserDto userDTO)
    {
        return await _userManager.FindByNameAsync(userDTO.Email);
    }

    public async Task<IdentityResult> Register(UserDto userDTO)
    {
        var user = new IdentityUser
        {
            UserName = userDTO.Email
        };

        return await _userManager.CreateAsync(user, userDTO.Password);
    }

    public async Task<bool> CheckPasswords(IdentityUser user, UserDto userDTO)
    {
        return await _userManager.CheckPasswordAsync(user, userDTO.Password);
    }

}
