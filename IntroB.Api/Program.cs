using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using IntroB.Api.DataAccess;
using IntroB.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var fileContextOptions = new FileContextOptions<AppFileContext>(Path.Combine(builder.Environment.ContentRootPath, "Data/Storage"));

builder.Services.AddSingleton<IFileContextOptions<IFileContext>>(fileContextOptions);
builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
{
    var options = provider.GetRequiredService<IFileContextOptions<IFileContext>>();
    var dataContext = new AppFileContext(options);
    dataContext.FetchAsync().AsTask().Wait();

    return dataContext;
});

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();