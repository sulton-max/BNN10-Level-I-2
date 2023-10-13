namespace DependencyInjection.Provider.Api.Services;

public class SingletonService
{
    private readonly ScopedService _service;

    public SingletonService(ScopedService service)
    {
        _service = service;
    }
}