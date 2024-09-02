using FluentValidation.Results;
using MultiGames.Domain.Entities.Base;
using MultiGames.Domain.Validations;

namespace MultiGames.Domain.Entities;

public class BrotherDomain : BaseDomain
{
    readonly BrotherDomainValidator userDomainValidator = new();

    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public AddressDomain Address { get; private set; }
    public ICollection<GameDomain> Games { get; private set; }

    private BrotherDomain()
    {
        
    }

    public BrotherDomain(string name, 
                         string cpf, 
                         string email,
                         Guid id, 
                         DateTimeOffset dateCriate) : 
                         base(id, dateCriate)

    {
        Name = name;
        Cpf = cpf;
        Email = email;
    }

    public ValidationResult BrotherDomainValidationReuslt()
    {
        return userDomainValidator.Validate(this);
    }
  
}
