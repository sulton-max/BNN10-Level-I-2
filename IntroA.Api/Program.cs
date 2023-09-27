var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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