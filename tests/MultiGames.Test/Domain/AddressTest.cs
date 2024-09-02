using MultiGames.Domain.Validations;

namespace MultiGamesDomain.Tests.Domain;

public class AddressTest
{
   private AddressDomainValidator validator;


    [SetUp]
    public void Setup()
    {
        validator = new AddressDomainValidator();
    }

    public void Veririficar_address_valido()
    {
        var AddressAnonnymus = new
        {
            Street = "Rua XPTO",
            StreetNumber = "1258",
            City = "Cidade X",
            Country = "Brasil",
            State = "Rio de Janeiro0",
            PostalCode = "24342-075",
            TelPhone = "(21)3741-5373",
            CelPhone = "(21)9 9908-0978"
        };

    }
}

