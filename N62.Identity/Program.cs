using N62.Identity.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TodoService>();
builder.Services.AddTransient<TokenGeneratorService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseAuthentication();
app.Run();