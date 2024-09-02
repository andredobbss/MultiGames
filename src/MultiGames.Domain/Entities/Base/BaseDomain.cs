namespace MultiGames.Domain.Entities.Base;

public class BaseDomain
{
    protected BaseDomain() { }

    public Guid Id { get; private set; } 
    public DateTimeOffset DateCriate { get; private set; }

    public BaseDomain(Guid id, DateTimeOffset dateCriate)
    {
        if (id.ToString() == "{00000000-0000-0000-0000-000000000000}" || id == Guid.Empty)
        {
            Id = Guid.NewGuid();
        }
        else
        {
            Id = id;
        }

        if (dateCriate.ToString() == "01/01/0001 00:00:00 +00:00")
        {
            DateCriate = DateTimeOffset.Now.ToUniversalTime();
        }
        else
        {
            DateCriate = dateCriate;
        }

    }

}




