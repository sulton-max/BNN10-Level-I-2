using N50_C.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Service lifecycle

// Singleton - requestga bog'liq bo'lmagan service
builder.Services.AddSingleton<SingletonService>();

// Scoped - requestga bog'liq service
builder.Services.AddScoped<ScopedService>();

// Transient - har bir request uchun yangi service yaratiladi
builder.Services.AddTransient<TransientService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();