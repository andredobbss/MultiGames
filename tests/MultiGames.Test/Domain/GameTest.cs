using MultiGames.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiGamesDomain.Tests.Domain;

public class GameTest
{
    private GameDomainValidator validator;


    [SetUp]
    public void Setup()
    {
        validator = new GameDomainValidator();
    }
}
