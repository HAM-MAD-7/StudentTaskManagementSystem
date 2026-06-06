using Microsoft.EntityFrameworkCore;
using StudentTaskManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var db_password = Environment.GetEnvironmentVariable("DB_Password");
var db_user = Environment.GetEnvironmentVariable("User");
var db_port = Environment.GetEnvironmentVariable("Port");
var db_server = Environment.GetEnvironmentVariable("Server");

var connect = builder.Configuration.GetConnectionString("DefaultConnection") + $"Password={db_password};" + $"User={db_user};" + $"Port={db_port};" + $"Server={db_server};";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connect, serverVersion: MySqlServerVersion.AutoDetect(connect));
});

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
