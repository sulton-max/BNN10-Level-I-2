var builder = WebApplication.CreateBuilder(args);

// service larni mana bu yerda registratsiya qilamiz
// builder.Services.AddScoped<IService, Service>();

// configuratsiya bu - business logikani to'g'ridan to'g'ri o'zgiratiradigan model
// configuratsiayalrni mana shu orqali registratsiya qilamiz
// builder.Configuration

// Add services to the container

// infrastructure configuration

// focus
// DI - service, swagger, context, controller
// Middleware - controller

builder.Services.AddControllers();

// dev tools
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// middleware configuration
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// http
// https
app.UseHttpsRedirection();

// authorization ma'lumotini tekshirad
app.UseAuthorization();

app.MapControllers();

app.Run();