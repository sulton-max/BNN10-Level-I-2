using Di.Api;
using Di.Api.DataAccess;
using Di.Api.Models.Entities;
using Di.Api.Services;
using FileBaseContext.Context.Models.Configurations;

var builder = WebApplication.CreateBuilder(args);

// SOLID -

// Single Responsibility - har bitta component faqat bitta vazifani bajarishi kerak
// Inversion Of Control - principle, har bitta component dependency ni tashqaridan olishi kerak

// Dependency Injection - pattern, dependencylar method orqali, propertylar orqali yoki construktor orqali
// depdencylarni olish

// Dependency Injection da operatsiyalar

//

// Registratsiya

// 1-usul - tipni belgilash, bunda yoki interfeys-class yoki class, class belgilanadi

// interfeys-class
builder.Services.AddScoped<IUserService, UserService>();

// class-class
// builder.Services.AddScoped<UserService, EncryptedUserService>();

// 2-usul tip va instance ni berish
builder.Services.AddSingleton<IFileContextOptions<AppFileContext>>(_ =>
{
    Console.WriteLine("FileContextOptions yaratildi");
    return new FileContextOptions<AppFileContext>()
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "Storage")
    };
});

builder.Services.AddScoped<IDataContext, AppFileContext>();

builder.Services.AddControllers();

// Swashbuckle.AspNetCore
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();