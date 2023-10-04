using N50_C.Models.Dtos;

namespace N50_C.Services;

public class UserService
{
    public event Func<ValueTask<bool>> OnUserRegisteredAsync;
    public Func<ValueTask<bool>> OnUserRegister;

    public ValueTask<bool> RegisterAsync(RegisterDetails registerDetails)
    {
        OnUserRegisteredAsync();
        OnUserRegister();
    }
}