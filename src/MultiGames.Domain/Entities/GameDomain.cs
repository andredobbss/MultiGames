using FluentValidation.Results;
using MultiGames.Domain.Entities.Base;
using MultiGames.Domain.Validations;

namespace MultiGames.Domain.Entities;

public class GameDomain : BaseDomain
{
    readonly GameDomainValidator validator = new();

    public string Title { get; private set; }
    public string VersionEdition { get; private set; }
    public string Status { get; private set; }
    public DateTimeOffset DateOut { get; private set; }
    public BrotherDomain Brother { get; private set; }

    private GameDomain()
    {
        
    }

    public GameDomain(string title,
                      string versionEdition,
                      string status,
                      DateTimeOffset dateOut,
                      Guid id,
                      DateTimeOffset dateCriate) :
                      base(id, dateCriate)
    {
        Title = title;
        VersionEdition = versionEdition;
        Status = status;
        DateOut = dateOut;
    }

    public ValidationResult GameDomainResult()
    {
        return validator.Validate(this);
    }
}
