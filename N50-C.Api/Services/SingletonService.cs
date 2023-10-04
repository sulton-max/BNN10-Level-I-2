namespace N50_C.Api.Services;

public class SingletonService
{
    public Guid Id { get; init; }

    public SingletonService()
    {
        Id = Guid.NewGuid();
        Console.WriteLine($"singleton service yaratildi {Id}");
    }
}