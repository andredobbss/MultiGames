using FluentValidation.TestHelper;
using MultiGames.Domain.Entities;
using MultiGames.Domain.Resources;
using MultiGames.Domain.Validations;


namespace MultiGamesDomain.Tests.Domain;

public class BrotherTest
{
    private BrotherDomainValidator validator;


    [SetUp]
    public void Setup()
    {
        validator = new BrotherDomainValidator();
    }

    [Test]
    public void verificar_usuario_valido()
    {
        var UserAnonnymus = new
        {
            Name = "André Dobbss",
            Cpf = "012.885.737-40",
            Email = "andredobbss@gmail.com",
            id = Guid.NewGuid(),
            CreateDate = DateTimeOffset.Now.ToUniversalTime(),
        };

        var user = new BrotherDomain(UserAnonnymus.Name, UserAnonnymus.Cpf, UserAnonnymus.Email, UserAnonnymus.id, UserAnonnymus.CreateDate);

        var result = validator.TestValidate(user);

        result.ShouldNotHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Name);
        result.ShouldNotHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Cpf);
        result.ShouldNotHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Email);
    }


    [Test]
    public void verificar_usuario_em_branco()
    {
        var UserAnonnymus = new
        {
            Name = string.Empty,
            Cpf = string.Empty,
            Email = string.Empty
        };

        //var user = new BrotherDomain(UserAnonnymus.Name, UserAnonnymus.Cpf, UserAnonnymus.Email);

        //var result = validator.TestValidate(user);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Name)
        //    .WithErrorMessage(MultiGames_Resource.UserNameEmpty);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Cpf)
        //    .WithErrorMessage(MultiGames_Resource.CpfEmpty);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Email)
        //    .WithErrorMessage(MultiGames_Resource.EmailEmpty);

        //Assert.Pass();


    }

    [Test]
    public void verificar_usuario_nulo()
    {
        var UserAnonnymus = new
        {
            Name = string.Empty,
            Cpf = string.Empty,
            Email = string.Empty
        };

        //var user = new BrotherDomain(null, null, null);

        //var result = validator.TestValidate(user);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Name)
        //    .WithErrorMessage(MultiGames_Resource.UserNameNull);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Cpf)
        //    .WithErrorMessage(MultiGames_Resource.CpfNull);

        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Email)
        //      .WithErrorMessage(MultiGames_Resource.EmailNull);

        //Assert.Pass();
    }

    [Test]
    public void verificar_email_invalido()
    {
        var UserAnonnymus = new
        {
            Name = string.Empty,
            Cpf = string.Empty,
            Email = "andre"
        };

        //var user = new BrotherDomain(null, null, UserAnonnymus.Email);

        //var result = validator.TestValidate(user);


        //result.ShouldHaveValidationErrorFor(UserAnonnymus => UserAnonnymus.Email)
        //    .WithErrorMessage(MultiGames_Resource.EmailInvalid);

        //Assert.Pass();
    }
}