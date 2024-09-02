using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiGames.Application.DTOs;
using MultiGames.Application.IUofW;
using MultiGames.Application.Pagination;
using MultiGames.Domain.Entities;
using Newtonsoft.Json;
using System.Data;
using X.PagedList;

namespace MultiGames.Api.Controllers;


[ApiController]
[Route("v1/api/[controller]")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BrothersController : ControllerBase
{

    private readonly IValidator<BrotherDomain> _validator;

    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;

    public BrothersController(IValidator<BrotherDomain> validator,
                           IMapper mapper,
                           IUnitOfWork unitOfWork)

    {
        _validator = validator;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    /// <summary>
    /// Retorna todos os amigos da lista
    /// </summary>
    /// <returns>Retorna todos os amigos da lista</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Request bem sucedido</response>
    /// <response code = "404">Request não encontrou registros</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpGet("GetBrothers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<BrotherDto>>> Get()
    {
        try
        {
            //var brother = await _unitOfWork.IBrotherRepository.GetAllAsync()
            //                                                  .Include(a => a.Address)
            //                                                  .Include(b => b.Games)
            //                                                  .OrderBy(b => b.Name)
            //                                                  .ToListAsync();

            var sql = "select b.*, a.*, g.* from Brothers b left join Adresses a on b.AddressId = a.Id left join Games g on g.BrotherId =b.Id order by b.Name";


            var brother = await _unitOfWork.IBrotherRepository.GetDapper(sql);


            var brotherDto = _mapper.Map<List<BrotherDto>>(brother);

            if (brotherDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "A lista está vazia!");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, brotherDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

   
    /// <summary>
    /// Retorna os amigos por página
    /// </summary>
    /// <returns>Retorna os amigos por página</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Request bem sucedido</response>
    /// <response code = "404">Request não encontrou registros</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpGet("GetBrothersPagedList")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<BrotherDto>>> GetBrothersPagedList([FromQuery] ParametersPagination parametersPagination)
    {
        try
        {
            var brother = await _unitOfWork.IBrotherRepository.GetAllAsync()
                                                              .Include(a => a.Address)
                                                              .Include(b => b.Games)
                                                              .Where(b => b.Name.Contains(parametersPagination.Find))
                                                              .OrderBy(b => b.Name)
                                                              .ToPagedListAsync(parametersPagination.PageNumber,
                                                                                parametersPagination.PageSize);

            var metadata = new
            {
                brother.PageNumber,
                brother.PageSize,
                brother.FirstItemOnPage,
                brother.LastItemOnPage,
                brother.TotalItemCount,
                brother.HasPreviousPage,
                brother.HasNextPage
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            Response.Headers.Add("PageNumber", brother.PageNumber.ToString());
            Response.Headers.Add("PageSize", brother.PageSize.ToString());
            Response.Headers.Add("FirstItemOnPage", brother.FirstItemOnPage.ToString());
            Response.Headers.Add("LastItemOnPage", brother.LastItemOnPage.ToString());
            Response.Headers.Add("TotalItemCount", brother.TotalItemCount.ToString());
            Response.Headers.Add("HasPreviousPage", brother.HasPreviousPage.ToString());
            Response.Headers.Add("HasNextPage", brother.HasNextPage.ToString());

            var brotherDto = _mapper.Map<List<BrotherDto>>(brother);

            if (brotherDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "A lista está vazia!");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, brotherDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

    /// <summary>
    /// Retorna um amigo por Id
    /// </summary>
    /// <returns>Retorna um amigo por Id</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Request bem sucedido</response>
    /// <response code = "404">Request não encontrou registros</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpGet("GetBrotherById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<BrotherDto>> GetById(Guid id)
    {
        try
        {
            var brother = await _unitOfWork.IBrotherRepository.GetById(b => b.Id == id);

            var brotherDto = _mapper.Map<BrotherDto>(brother);

            if (brotherDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Brother não encontrado");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, brotherDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

    /// <summary>
    /// Cria um amigo
    /// </summary>
    /// <returns>Cria um amigo</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Sucesso na criação de um amigo</response>
    /// <response code = "404">Insucesso na criação de un amigo</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpPost("PostBrother")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] BrotherDto brotherDto)
    {
        try
        {
            var brother = _mapper.Map<BrotherDomain>(brotherDto);

            var result = _validator.Validate(brother);

            if (result.IsValid)
            {
                _unitOfWork.IBrotherRepository.Add(brother);

                await _unitOfWork.Commit();

                _unitOfWork.Dispose();

                return StatusCode(StatusCodes.Status200OK, "Processo finalizado com sucesso");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, result.ToDictionary());
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

    /// <summary>
    /// Atualiza informações de um amigo
    /// </summary>
    /// <returns>Atualiza informações de um amigo</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Sucesso na atualização de um amigo</response>
    /// <response code = "400">Insucesso na atualização de un amigo</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpPut("PutBrother")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] BrotherDto brotherDto)
    {
        try
        {
            var brother = _mapper.Map<BrotherDomain>(brotherDto);

            var result = _validator.Validate(brother);

            if (result.IsValid)
            {
                if (brother.Id != id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id não correspodente.");
                }
                else
                {
                    _unitOfWork.IBrotherRepository.Update(brother);

                    await _unitOfWork.Commit();

                    _unitOfWork.Dispose();

                    return StatusCode(StatusCodes.Status200OK, "Processo finalizado com sucesso");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.ToDictionary());
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

    /// <summary>
    /// Remove um amigo da lista
    /// </summary>
    /// <returns>Remove um amigo da lista</returns>
    /// <remarks>
    /// 
    /// </remarks>
    /// <response code = "200">Sucesso na remoção de um amigo</response>
    /// <response code = "400">Insucesso na remoção de un amigo</response>
    /// <response code = "500">Problema interno. Servidor indisponível</response>
    [HttpDelete("DeleteBrother")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var brother = await _unitOfWork.IBrotherRepository.GetById(b => b.Id == id);

            if (brother == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Id não correspodente.");
            }
            else
            {
                _unitOfWork.IBrotherRepository.Delete(brother);

                await _unitOfWork.Commit();

                _unitOfWork.Dispose();

                var brotherDto = _mapper.Map<BrotherDto>(brother);

                return StatusCode(StatusCodes.Status200OK, brotherDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }
}
