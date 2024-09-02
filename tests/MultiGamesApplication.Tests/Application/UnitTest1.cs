using AutoMapper;
using MultiGames.Application.DTOs;
using MultiGames.Application.IUofW;
using MultiGames.Application.Repository;
using MultiGames.Domain.Entities;
using NSubstitute;

namespace MultiGamesApplication.Tests.Application;

public class UnitTest1
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    public UnitTest1(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Fact]
    public void Test1()
    {
        var brotherDomain = _unitOfWork.IBrotherRepository.GetAllAsync();

        var brotherDTO = _mapper.Map<List<BrotherDto>>(brotherDomain);

        //Assert.NotNull(brotherDTO);

        Assert.IsType<List<BrotherDto>>(brotherDTO);
    }
}