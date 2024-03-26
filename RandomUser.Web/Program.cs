using RandomUser.Web.Service;
using RandomUser.Web.Service.IService;
using RandomUser.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
//builder.Services.AddHttpClient<IBaseService, BaseService>();
SD.RandomUserAPIBase = builder.Configuration["ServiceUrls:RandomUserGenApi"];
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IRandomUserService, RandomUserService>();
builder.Services.AddScoped<IHealthCheckService, HealthCheckService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=RandomUserGen}/{action=Index}/{id?}");
     pattern: "{controller=RandomUserGen}/{action=HealthCheck}/{id?}");

app.Run();
