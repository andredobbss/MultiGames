using FluentValidation;
using MultiGames.Domain.Entities;
using MultiGames.Domain.Resources;

namespace MultiGames.Domain.Validations;

public class BrotherDomainValidator : AbstractValidator<BrotherDomain>
{
    public BrotherDomainValidator() 
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage(MultiGames_Resource.UserNameEmpty);
        RuleFor(u => u.Name).NotNull().WithMessage(MultiGames_Resource.UserNameNull);

        RuleFor(u => u.Cpf).NotEmpty().WithMessage(MultiGames_Resource.CpfEmpty);
        RuleFor(u => u.Cpf).NotNull().WithMessage(MultiGames_Resource.CpfNull);

        RuleFor(u => u.Email).NotEmpty().WithMessage(MultiGames_Resource.EmailEmpty);
        RuleFor(u => u.Email).NotNull().WithMessage(MultiGames_Resource.EmailNull);
        
        When(u => !string.IsNullOrWhiteSpace(u.Email), () => {
            RuleFor(u => u.Email).EmailAddress().WithMessage(MultiGames_Resource.EmailInvalid);
        });
    }
}
