namespace N50_C.Api.Services;

public class TransientService
{
    public Guid Id { get; init; }

    public TransientService()
    {
        Id = Guid.NewGuid();
        Console.WriteLine($"transient service yaratildi {Id}");
    }
}