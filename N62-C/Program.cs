using System.Net;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// middleware

// why - request yoki responselarni modifikatsiya qilmoqchi bo'lsak
// what - asp.net core dagi requestlarni process qiladigan eng kichik component
// when - requestni biror joyga yozib ketmoqchi bo'lsak, requestni kim jo'natayotgani ma'lumotini qo'shmoqchi bo'ljak
// how - built-in middlewarelardan foydalanib, yoki custom middleware dan foydalanib

// custom middleware - requestdagi ma'lumotlarni faylga yozish
// context - HttpContext bu request va response ni o'zida ushlaydigan model
// next - keyingi middleware componentga uzatish uchun delegate

// bu custom middleware request haqidagi ma'lumotni faylga yozib ketadi
app.Use(async (context, next) =>
{
    var message =
        $"{DateTimeOffset.Now:u} request path - {context.Request.Path} with method {context.Request.Method} from IP address {context.Connection.RemoteIpAddress}";

    await using var fileStream = File.Open("log.txt", FileMode.Append, FileAccess.Write);
    await using var streamWriter = new StreamWriter(fileStream);
    await streamWriter.WriteLineAsync(message);

    await next();
});

// custom middleware - requestni validatsiya qilish, path to'g'ri kelsa o'zi javob berish yoki keyingi middleware componentga uzatish


// app.MapControllers();
app.MapGet("/", () => Results.Ok("Hello World!"));

app.Use(async (context, next) =>
{
    Console.WriteLine($"Intercepting request {context.Request.Path.ToString()}");

    if (string.IsNullOrWhiteSpace(context.Request.Headers.Authorization.ToString()))
    {
        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        await context.Response.WriteAsync("Userni bejiki yo'q ekan");
        return;
    }

    if (context.Request.Path == "/hello")
        await context.Response.WriteAsync("No endpoint found");
    else
        await next();
});

// Func<HttpContext, RequestDelegate, Task
// custom middleware - vazifasi biror middleware requestni qabul qilmasa mana shu middleware qabul qiladi

// terminal middleware
// app.Run(async context =>
// {
//     Console.WriteLine($"Intercepting request {context.Request.Path.ToString()}");
//     await context.Response.WriteAsync("No endpoint found");
// });

app.Run();