using N49_C.Monolith.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserSer()

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();