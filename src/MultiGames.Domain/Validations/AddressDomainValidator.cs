using FluentValidation;
using MultiGames.Domain.Entities;
using MultiGames.Domain.Resources;

namespace MultiGames.Domain.Validations;

public class AddressDomainValidator : AbstractValidator<AddressDomain>
{
   public AddressDomainValidator()
    {
        RuleFor(a => a.Street).NotEmpty().WithMessage(MultiGames_Resource.StreetEmpty);
        RuleFor(a => a.Street).NotNull().WithMessage(MultiGames_Resource.StreetNull);

        RuleFor(a => a.StreetNumber).NotEmpty().WithMessage(MultiGames_Resource.StreetNumberEmpty);
        RuleFor(a => a.StreetNumber).NotNull().WithMessage(MultiGames_Resource.StreetNumberNull);

        RuleFor(a => a.City).NotEmpty().WithMessage(MultiGames_Resource.CityEmpty);
        RuleFor(a => a.City).NotNull().WithMessage(MultiGames_Resource.CityNull);

        RuleFor(a => a.Country).NotEmpty().WithMessage(MultiGames_Resource.CountryEmpty);
        RuleFor(a => a.Country).NotNull().WithMessage(MultiGames_Resource.CountryNull);

        RuleFor(a => a.State).NotEmpty().WithMessage(MultiGames_Resource.StateEmpty);
        RuleFor(a => a.State).NotNull().WithMessage(MultiGames_Resource.StreetNull);

        RuleFor(a => a.PostalCode).NotEmpty().WithMessage(MultiGames_Resource.PostalCodeEmpty);
        RuleFor(a => a.PostalCode).NotNull().WithMessage(MultiGames_Resource.PostalCodeNull);

        RuleFor(a => a.TelPhone).NotEmpty().WithMessage(MultiGames_Resource.TelPhoneEmpty);
        RuleFor(a => a.TelPhone).NotNull().WithMessage(MultiGames_Resource.TelPhoneNull);
        RuleFor(a => a.TelPhone).NotNull().WithMessage(MultiGames_Resource.TelPhoneInvalid);

        RuleFor(a => a.CelPhone).NotEmpty().WithMessage(MultiGames_Resource.CelPhoneEmpty);
        RuleFor(a => a.CelPhone).NotNull().WithMessage(MultiGames_Resource.CelPhoneNull);
        RuleFor(a => a.CelPhone).NotNull().WithMessage(MultiGames_Resource.CelPhoneInvalid);
    }
}
