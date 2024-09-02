using FluentValidation.Results;
using MultiGames.Domain.Entities.Base;
using MultiGames.Domain.Validations;

namespace MultiGames.Domain.Entities;

public class AddressDomain : BaseDomain
{
    readonly AddressDomainValidator addressDomainValidator = new();

    public string Street { get; private set; }
    public string StreetNumber { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string TelPhone { get; private set; }
    public string CelPhone { get; private set; }
    public ICollection<BrotherDomain> Brothers { get; private set; }

    private AddressDomain()
    {
        
    }

    public AddressDomain(string street,
                         string streetNumber,
                         string city,
                         string country,
                         string state,
                         string postalCode,
                         string telPhone,
                         string celPhone,
                         Guid id,
                         DateTimeOffset dateCriate) :
                         base(id, dateCriate)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        Country = country;
        State = state;
        PostalCode = postalCode;
        TelPhone = telPhone;
        CelPhone = celPhone;
    }

    public ValidationResult AddresDomainResult()
    {
        return addressDomainValidator.Validate(this);
    }


}
