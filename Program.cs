using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using coreWebApplication.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<coreWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("coreWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'coreWebApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); 

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
