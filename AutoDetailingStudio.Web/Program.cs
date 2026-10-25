using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoDetailingStudio.Data;
using AutoDetailingStudio.Data.Models;
using AutoDetailingStudio.Services.Core;
using AutoDetailingStudio.Services.Core.Contracts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
    {
        ConfigureIdentityOptions(options, builder.Configuration);
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();  

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

static void ConfigureIdentityOptions(IdentityOptions options,
    IConfiguration configuration)
{
    options.Password.RequireLowercase =
        configuration.GetValue<bool>("Identity:Password:RequireLowercase");

    options.Password.RequireUppercase =
        configuration.GetValue<bool>("Identity:Password:RequireUppercase");

    options.Password.RequireNonAlphanumeric =
        configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

    options.Password.RequiredLength =
        configuration.GetValue<int>("Identity:Password:RequiredLength");

    options.Password.RequiredUniqueChars =
        configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

    options.User.RequireUniqueEmail =
        configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
    
    options.Password.RequireDigit =
        configuration.GetValue<bool>("Identity:Password:RequireDigit");

    options.SignIn.RequireConfirmedAccount =
        configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
    
}