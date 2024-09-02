using MultiGames.Application.DTOs.Base;

namespace MultiGames.Application.DTOs;

public class BrotherDto : BaseDto
{
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Email { get; set; }
    public AddressDto Address { get; set; }
    public ICollection<GameDto> Games { get; set; }

}
