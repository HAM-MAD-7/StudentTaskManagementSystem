using Microsoft.EntityFrameworkCore;
using StudentTaskManagementSystem.Data;
using StudentTaskManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<BlobStorageService>();

var connect = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connect, serverVersion: MySqlServerVersion.AutoDetect(connect));
});

builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StudentTask}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
