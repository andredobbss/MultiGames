using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiGames.Application.Authentication.Repository;
using MultiGames.Application.Authorization.Repository;
using MultiGames.Application.Authorization.UserIdentityDTO;

namespace MultiGames.Api.Controllers;


[Route("v1/api/[controller]")]
[Produces("application/json")]
[ApiController]
public class AuthorizerController : ControllerBase
{
    private readonly IAuthorizationRepository _authorizationRepository;
    private readonly IAuthenticationRepository _authenticationRepository;
    private readonly IConfiguration _configuration;

    public AuthorizerController(IAuthorizationRepository authorizationRepository, 
                                IAuthenticationRepository authenticationRepository, 
                                IConfiguration configuration)
    {
        _authorizationRepository = authorizationRepository;
        _authenticationRepository = authenticationRepository;
        _configuration = configuration;
    }


    /// <summary>
    /// Cria um usuário
    /// </summary>
    /// <returns>Cria um usuário</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Sucesso na criação de um usuário</response>
    /// <response code = "400">Insucesso na criação de um usuário</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RegisterUser([FromBody] UserDto userModel)
    {
        try
        {
            var result = await _authorizationRepository.Register(userModel);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK, "Registro de usuário efetuado com sucesso!");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.Errors);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }       
    }

    /// <summary>
    /// Autentica o usuário
    /// </summary>
    /// <returns>Autentica o usuário</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Sucesso na autenticação</response>
    /// <response code = "400">Insucesso na autenticação</response>
    /// <response code = "404">Login inválido</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] UserDto userModel)
    {
        try
        {
            var user = await _authorizationRepository.Login(userModel);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Login Iválido");
            }
            else
            {
                var correctPassword = await _authorizationRepository.CheckPasswords(user, userModel);

                if (correctPassword)
                {
                    return StatusCode(StatusCodes.Status200OK, _authenticationRepository.GenerateToken(userModel, _configuration));
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Login Iválido");
                }
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }    
    }


}
