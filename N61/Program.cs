using N61.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseMvc(options => options.)
app.MapControllers();

app.UseHsts();
app.UseHttpsRedirection();

// app.UseEndpoints(configure =>
// {
//     // configure.MapControllers();
//     configure.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}/files/{id?}")
// });

// app.UseAuthorization();

app.MapControllers();
app.Run();