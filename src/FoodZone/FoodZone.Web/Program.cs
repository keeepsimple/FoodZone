using FoodZone.Data;
using FoodZone.Data.Infrastructure;
using FoodZone.Models.Security;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FoodZoneCnn");
builder.Services.AddDbContext<FoodZoneContext>(opt =>
opt.UseSqlServer(connectionString));

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

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMenuServices, MenuServices>();
builder.Services.AddScoped<IFoodServices, FoodServices>();
builder.Services.AddScoped<ISalaryServices, SalaryServices>();
builder.Services.AddScoped<ITableServices, TableServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<IReservationServices, ReservationServices>();
builder.Services.AddScoped<IReservationDetailServices, ReservationDetailServices>();
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

app.MapControllerRoute(
     name: "admin",
     pattern: "{area:exists}/{controller=admin}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
