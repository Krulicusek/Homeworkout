using homeWorkOutApi.Net6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using homeWorkOutApi.Net6._0.Data;
var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapRazorPages();

app.Run();


builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json");
   
});

AppSettings appSettings = new AppSettings(configuration);
appSettings.GetServerSettings();

if (!string.IsNullOrEmpty(appSettings?.ServerSettings?.ConnectionString))
{
  builder.Services.AddDbContext<homeWorkOutApiNet6_0Context>(options =>
  options.UseSqlServer(appSettings.ServerSettings.ConnectionString));
}
builder.Services.AddDbContext<homeWorkOutApiNet6_0Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("homeWorkOutApiNet6_0Context")));