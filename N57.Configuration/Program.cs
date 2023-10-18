using Microsoft.Extensions.Options;
using N57.Configuration.Models;
using N57.Configuration.Models.Settings;
using N57.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Configuration.

// External configuration


// EmailEnabled
// INotificationService - EmailSenderService yoki SmsSenderService

// Primitive qiymatlarni olish

builder.Configuration.

var orderValue = builder.Configuration.GetSection("OrderSettings:BonusPercentages:Name").Get<int>();

var orderSettings = builder.Configuration.GetSection("OrderSettings").Get<OrderSettings>();

// builder.Configuration.Get<>()

// bu konfiguratsiyadan OrderSettings nomli sectionni olib, OrderSettings modelga aylantriib dependency injectionga yozib qo'yish degani

builder.Services.Configure<OrderSettings>(builder.Configuration.GetSection(nameof(OrderSettings)));


// builder.Services.AddSingleton<OrderSettings>(provider => provider.GetRequiredService<IOptions<OrderSettings>>().Value);

builder.Services.AddScoped<OrderService>().AddSingleton<BonusService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();