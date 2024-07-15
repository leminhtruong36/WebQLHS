using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebQLHS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Get the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("QLHS_1Connection");
Console.WriteLine($"Connection String: {connectionString}"); // Debug line

// Add DbContext using SQL Server provider
builder.Services.AddDbContext<QLHS_1Context>(options =>
    options.UseSqlServer(connectionString));

// Add session support
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Use custom error page in non-development environments
    app.UseExceptionHandler("/Home/Error");
}



// Configure request localization
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("vi-VN")
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Access}/{action=Login}/{id?}");
});

app.Run();
