using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using N58_C.Models.Settings;
using N58_C.Service;

var builder = WebApplication.CreateBuilder(args);

// .net 7 da bu avtomatik qo'shiladi
// builder.Configuration.AddUserSecrets(typeof(Program).Assembly);

builder.Services.AddScoped<EmailSenderService>();

builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));

var app = builder.Build();

var emailSenderService = app.Services.CreateScope().ServiceProvider.GetRequiredService<EmailSenderService>();
emailSenderService.SendEmail("sultonbek.rakhimov@gmail.com", "Sultonbek");

app.Run();