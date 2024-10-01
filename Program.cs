using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GOTG.ST10097679.Final.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure your database connection string
var connectionString = builder.Configuration.GetConnectionString("DBContextConnection") ?? throw new InvalidOperationException("Connection string 'DBContextConnection' not found.");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

// Add identity services
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DBContext>();

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "volunteer",
    pattern: "{controller=Volunteer}/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "donation",
    pattern: "{controller=Donation}/{action=Create}/{id?}");

app.MapRazorPages();

app.Run();



