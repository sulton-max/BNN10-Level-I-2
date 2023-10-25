using System.Globalization;
using N63.Middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<CultureMiddleware>();
app.MapGet("/", () => DateTime.Now.ToString(CultureInfo.CurrentCulture));

app.Run();