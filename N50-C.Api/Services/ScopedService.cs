namespace N50_C.Api.Services;

public class ScopedService
{
    public Guid Id { get; init; }

    public ScopedService()
    {
        Id = Guid.NewGuid();
        Console.WriteLine($"scoped service yaratildi {Id}");
    }
}