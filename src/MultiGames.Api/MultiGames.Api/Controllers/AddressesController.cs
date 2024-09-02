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
using X.PagedList;

namespace MultiGames.Api.Controllers;

[ApiController]
[Route("v1/api/[controller]")]
[Produces("application/json")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AddressesController : ControllerBase
{
    private readonly IValidator<AddressDomain> _validator;

    private readonly IMapper _mapper;

    private readonly IUnitOfWork _unitOfWork;


    public AddressesController(IValidator<AddressDomain> validator, 
                               IMapper mapper, 
                               IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    [HttpGet("GetAddresses")]
    public async Task<ActionResult<IEnumerable<AddressDomain>>> GetAll()
    {
        try
        {
            var address = await _unitOfWork.IAddressRepository.GetAllAsync()
                                                              .Include(e => e.Brothers)
                                                              .ToListAsync();

            var addressDto = _mapper.Map<List<AddressDto>>(address);

            if (addressDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "A lista está vazia!");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, addressDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }       
    }

    [HttpGet("GetAddressPagedList")]
    public async Task<ActionResult<IEnumerable<AddressDomain>>> GetAddressPagedList([FromQuery] ParametersPagination parametersPagination)
    {
        try
        {
            var address = await _unitOfWork.IAddressRepository.GetAllAsync()
                                                              .Include(e => e.Brothers)
                                                              .Where(e => e.Street.Contains(parametersPagination.Find))
                                                              .OrderBy(e => e.Street)
                                                              .ToPagedListAsync(parametersPagination.PageNumber, parametersPagination.PageSize);

            var Metadata = new
            {
                address.PageNumber, 
                address.PageSize,
                address.FirstItemOnPage, 
                address.LastItemOnPage,
                address.TotalItemCount,
                address.HasNextPage,
                address.HasPreviousPage,
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(Metadata));
            
            var addressDto = _mapper.Map<List<AddressDto>>(address);

            if(addressDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "A lista está vazia!");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, addressDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }

    [HttpGet("GetAddressById/{id}")]
    public async Task<ActionResult<AddressDomain>> GetAddressById(Guid id)
    {
        try
        {
            var address = await _unitOfWork.IAddressRepository.GetById(a => a.Id == id);

            var addressDto = _mapper.Map<AddressDto>(address);

            if (addressDto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Endereço não encontrado");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, addressDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }     
    }

    [HttpPost("PostAddress")]
    public async Task<IActionResult> Post([FromBody] AddressDto addressDto)
    {
        try
        {
            var addressDomain =  _mapper.Map<AddressDomain>(addressDto);

            var result = _validator.Validate(addressDomain);

            if (result.IsValid)
            {
                _unitOfWork.IAddressRepository.Add(addressDomain);

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

    [HttpPut("PutAddress")]
    public async Task<IActionResult> Put(Guid id, [FromBody] AddressDto addressDto)
    {
        try
        {
            var addressDomain = _mapper.Map<AddressDomain>(addressDto);

            var result = _validator.Validate(addressDomain);

            if (result.IsValid)
            {
                if (addressDomain.Id != id)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id não correspodente.");
                }
                else
                {
                    _unitOfWork.IAddressRepository.Update(addressDomain);

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

    [HttpDelete("DeleteAddress")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var address = await _unitOfWork.IAddressRepository.GetById(a => a.Id == id);

            if (address == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Id não correspodente.");
            }
            else
            {
                _unitOfWork.IAddressRepository.Delete(address);

                await _unitOfWork.Commit();

                _unitOfWork.Dispose();

                var addressDto = _mapper.Map<AddressDto>(address);

                return StatusCode(StatusCodes.Status200OK, addressDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado. Favor contatar o suporte.");
        }
    }
}
