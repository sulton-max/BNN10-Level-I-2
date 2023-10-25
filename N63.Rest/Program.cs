using N63.Rest.Filters;
using N63.Rest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<OrderService>().AddScoped<EmailSenderService>().AddScoped<OrderProcessingService>();
builder.Services.AddControllers(configs => configs.Filters.Add<ExceptionFilter>());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();