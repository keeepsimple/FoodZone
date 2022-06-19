using FoodZone.Data;
using FoodZone.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FoodZoneContextConnection") ?? throw new InvalidOperationException("Connection string 'FoodZoneContextConnection' not found.");

builder.Services.AddDbContext<FoodZoneContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<Account>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FoodZoneContext>();;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FoodZoneCnn");
builder.Services.AddDbContext<FoodZoneContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Account>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FoodZoneContext>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredLength = 6;
});

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
