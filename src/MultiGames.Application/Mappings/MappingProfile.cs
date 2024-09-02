using AutoMapper;
using MultiGames.Application.DTOs;
using MultiGames.Domain.Entities;

namespace MultiGames.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddressDomain, AddressDto>().ReverseMap();
        CreateMap<BrotherDomain, BrotherDto>().ReverseMap();
        CreateMap<GameDomain, GameDto>().ReverseMap();
    }

   
}
