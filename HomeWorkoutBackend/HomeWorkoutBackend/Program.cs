using homeWorkOutApi.Net6._0.Data;
using homeWorkOutApi.Net6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json");
});

AppSettings appSettings = new AppSettings(configuration);
appSettings.GetServerSettings();

if (!string.IsNullOrEmpty(appSettings?.ServerSettings?.ConnectionString))
{
    builder.Services.AddDbContext<HomeWorkoutContext>(options =>
    options.UseSqlServer(appSettings.ServerSettings.ConnectionString));
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


