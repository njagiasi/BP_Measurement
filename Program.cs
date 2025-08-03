using Microsoft.EntityFrameworkCore;
using BPMeasurementApp.Entities;

var builder = WebApplication.CreateBuilder(args);

// Reads the connection string from appSettings.json using the key:
var connStr = builder.Configuration.GetConnectionString("BPMeasurementConnection");

// Add services to the container.

// Setting up the use of our DbContext object and telling it to use
// MS SQL Server and access the DB using the connection string we pass:
builder.Services.AddDbContext<BPMeasurementDbContext>(options => options.UseSqlServer(connStr));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
