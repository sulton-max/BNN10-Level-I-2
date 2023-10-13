using DependencyInjection.Request.Api.Data.SeedData;
using DependencyInjection.Request.Api.DataAccess;
using DependencyInjection.Request.Api.Services;
using FileBaseContext.Context.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<SingletonService>().AddScoped<ScopedService>().AddTransient<TransientService>();

// GetService - service ni olamiz
// GetRequiredService - service ni so'rash va topilmasa exception bo'ladi
// CreateScope - scoped service uchun scope yaratamiz
// CreateAsyncScope - scoped service uchun scope yaratadi faqat asinxron usulda


// var options = new FileContextOptions<AppFileContext>
// {
//     StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
// };
//
// // Registratsiya qilish - to'g'ridan to'g'ri instanceni o'zini
// builder.Services.AddSingleton<IFileContextOptions<AppFileContext>>(options);

// Registratiya qilish - lambda expression -

builder.Services.AddSingleton<IFileContextOptions<AppFileContext>>(_ => new FileContextOptions<AppFileContext>
{
    StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "DataStorage")
});

builder.Services.AddSingleton<AppFileContext>();

var app = builder.Build();

// service locator pattern
// await using var scope = app.Services.CreateAsyncScope();
// await scope.ServiceProvider.GetRequiredService<AppFileContext>().InitializeSeedDataAsync();

await app.Services.GetRequiredService<AppFileContext>().InitializeSeedDataAsync();

// var testA = app.Services.GetRequiredService<SingletonService>();
// var testB = app.Services.CreateScope().ServiceProvider.GetRequiredService<ScopedService>();
// var testC = app.Services.GetRequiredService<TransientService>();

// app.MapGet("/", () => "Hello World!");
await app.RunAsync();