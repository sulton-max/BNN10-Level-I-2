using N63.Identity.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AuthService>();
builder.Services.AddTransient<TokenGeneratorService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();