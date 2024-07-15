using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Tải cấu hình từ appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

var connectionString = builder.Configuration.GetConnectionString("QLHS_1Connection");
Console.WriteLine($"Connection String: {connectionString}"); // Debug line

builder.Services.AddDbContext<QLHS_1Context>(options =>
options.UseSqlServer(connectionString));

//builder.Services.AddIdentity<TaiKhoan, IdentityRole>()
//        .AddEntityFrameworkStores<QLHS_1Context>()
//        .AddDefaultTokenProviders();


builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

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
