using MultiGames.Application.DTOs.Base;

namespace MultiGames.Application.DTOs;

public class AddressDto : BaseDto
{ 
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string TelPhone { get; set; }
    public string CelPhone { get; set; }
    public ICollection<BrotherDto> Brothers { get; set; }

}
