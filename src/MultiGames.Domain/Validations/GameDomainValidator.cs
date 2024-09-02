using FluentValidation;
using MultiGames.Domain.Entities;

namespace MultiGames.Domain.Validations;

public class GameDomainValidator : AbstractValidator<GameDomain>
{
    public GameDomainValidator()
    {
        RuleFor(g => g.DateCriate).GreaterThan(g => g.DateOut).WithSeverity(Severity.Error).WithMessage("");
    }
}
