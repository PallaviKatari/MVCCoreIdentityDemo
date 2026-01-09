using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using MVCCoreIdentityDemo.Data;
using System;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add DB context
// Register ApplicationDbContext with SQL Server provider in the DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity
// Identity UI provides ready-made pages for:
// AccountController - Login,Register,Logout,Manage - We cannot see - available by default
// Account / Login
// Account / Register
// Account / Logout
// Account / Manage
// IdentityUser - default user class provided by Identity
// Identity uses Razor pages for its UI so add the middleware to map Razor pages
// app.MapRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Identity Authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Identity Razor Pages
app.MapRazorPages();

app.Run();
