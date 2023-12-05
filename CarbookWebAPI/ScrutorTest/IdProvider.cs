namespace CarbookWebAPI.ScrutorTest;

public class IdProvider : IGuidProvider, IStringIdProvider
{
    public Guid Id { get; } = Guid.NewGuid();

    public Guid GetID()
    {
        return Id;
    }

    public string GetId()
    {
        return Id.ToString();
    }
}