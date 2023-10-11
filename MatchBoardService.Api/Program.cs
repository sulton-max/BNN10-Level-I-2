using System.Reflection;
using System.Text.RegularExpressions;
using FileBaseContext.Context.Extensions;
using MatchBoardService.Api.Events;
using MatchBoardService.Api.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddLibrary();

// var services = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.InheritsOrImplements(typeof(IEntityService)) && x.IsClass).ToList();
// foreach (var service in services)
// {
//     builder.Services.Add(new ServiceDescriptor(service, service, ServiceLifetime.Singleton));
// }

// service descriptor - serviceni ifodalovchi object

// service descriptor ichidagi ma'lumotlar

// serviceni interfeysi - so'raladigan service tipi
// service ni implementatsiyasi - beriladigan service ni tipi
// provider - delegat, servicedan instance yaratib beradigan
// lifetime - service lifetime i

// new ServiceDescriptor()

// Remove - yozilgan servicelarni o'chirish
// builder.Services.Remove(ServiceDescriptor.Describe(typeof(IEntityService), typeof(MatchService), ServiceLifetime.Singleton));

// Replace - registratsiya qilingan servicelarni o'chirish
// builder.Services.Replace(ServiceDescriptor.Describe(typeof(IEntityService), typeof(TeamService), ServiceLifetime.Singleton));

// TryAdd - oldin bitta service registratiya qilinmagan bo'lsa qo'shadi
// builder.Services.TryAdd(ServiceDescriptor.Describe(typeof(IEntityService), typeof(TeamService), ServiceLifetime.Singleton));
// var service = builder.Services.ToList();

// bir nechta servicelarni regsitratsiya qilish
// - bunda agar bitta service request qilinsa oxirgi registratsiya qilingan service olinadi
// - bunda agar bir nechta service so'ralsa, servicelar kolleksiyasi keladi

// bir nechta servicelarni registratsiya qilish

// bunaqa qilmanglar!
// builder.Services.AddSingleton<IEntityService, MatchService>();
// builder.Services.AddSingleton<IEntityService, MatchService>();
// builder.Services.AddSingleton<IEntityService, MatchService>();
// builder.Services.AddSingleton<IEntityService, MatchService>();


builder
    .Services
    .AddSingleton<MatchEventStore>()
    .AddSingleton<MatchService>()
    .AddSingleton<UserService>()
    .AddSingleton<PromotionService>()
    .AddSingleton<TeamService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var test = app.Services.GetRequiredService<PromotionService>();

app.MapControllers();

app.Run();