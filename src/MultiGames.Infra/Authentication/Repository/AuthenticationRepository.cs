using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiGames.Application.Authentication.Repository;
using MultiGames.Application.Authentication.TokenDTO;
using MultiGames.Application.Authorization.UserIdentityDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiGames.Infra.Authentication.Repository;

public class AuthenticationRepository : IAuthenticationRepository
{
    public UserTokenDto GenerateToken(UserDto userDto, IConfiguration configuration)
    {
        // define delaraçoes do usuário
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, userDto.Email),
            new Claim("Company", "Task Plan"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // gera uma chave com base no algoritmo simétrico
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

        // gera a assinatura digital do token usando o algoritmo Hmac e a chave privada
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // tempo de expiração do Token
        var expire = configuration["TokenConfiguration:ExpireHours"];
        var expiration = DateTime.UtcNow.AddHours(double.Parse(expire));

        // classe que representa o JWT e gera o Token
        JwtSecurityToken token = new JwtSecurityToken(
                                                      audience: configuration["TokenConfiguration:Audience"],
                                                      issuer: configuration["TokenConfiguration:Issuer"],
                                                      claims: claims,
                                                      expires: expiration,
                                                      signingCredentials: credentials);

        return new UserTokenDto()
        {
            Authenticated = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
            Message = "Transação efetuada com sucesso!"
        };
    }
}
