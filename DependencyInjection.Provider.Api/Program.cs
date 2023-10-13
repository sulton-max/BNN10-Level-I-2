using DependencyInjection.Provider.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Qoida #1 - lifecycli kichik bo'lgan service ichiga lifecycle uzoq vaqt bo'lgan
// serviceni inject qilish mumkin, teskarisiga qilmaslik kerak


// Bitta service ichida o'zidan kichik lifecycledagi serviceni inject qilsak -
// o'sha instance ushlanib qoladi, agar scoped bo'lsa exception bo'ladi

builder
    .Services
    // .AddSingleton<SingletonService>()
    .AddSingleton<SingletonService>(provider =>
    {
        var serviceProvider = provider.CreateScope().ServiceProvider;

        return new SingletonService(serviceProvider.GetRequiredService<ScopedService>());
    })
    .AddScoped<ScopedService>()
    .AddTransient<TransientService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();