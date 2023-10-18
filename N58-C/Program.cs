using Microsoft.Extensions.Options;
using N58_C.Models.Settings;
using N58_C.Service;

// Convention over Configuration
var builder = WebApplication.CreateBuilder(args);

// Default configuration fayllar qanday qo'shilishi

// builder.Configuration.AddJsonFile("appsettings.json", false, true);
// var environment = builder.Environment.EnvironmentName;
// builder.Configuration.AddJsonFile($"appsettings.{environment}.json", false, true);

// Custom configuration fayllar qanday qo'shilishi
var environment = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile("ConfigurationFiles/notificationSettings.json", false, true);

if (environment == Environments.Development)
    builder.Configuration.AddJsonFile($"ConfigurationFiles/notificationSettings.{environment}.json", false, true);

// Configuration modelni registratsiya qilishni 1-usuli
// EmailSenderSettings - Strong-typed configuration objects
builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));
builder.Services.AddScoped<EmailSenderService>();

// Configuration modelni registratsiya qilishni 2-usuli
builder.Services.AddSingleton<EmailSenderSettings>(provider => provider.GetRequiredService<IOptions<EmailSenderSettings>>().Value);

var app = builder.Build();

var emailSenderService = app.Services.CreateScope().ServiceProvider.GetRequiredService<EmailSenderService>();
emailSenderService.SendEmail("sultonbek.rakhimov@gmail.com", "Sultonbek");

app.UseStaticFiles();
app.MapControllers();

app.Run();