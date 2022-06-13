using FoodZone.API.Configurations;
using FoodZone.Data;
using FoodZone.Data.Infrastructure;
using FoodZone.Models.Sercurity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//config log
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .WriteTo
    .File(path: "logs\\log-.txt",
    outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {Message:lj}{NewLine}{Exception}]",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: LogEventLevel.Information).CreateLogger();

// Add services to the container.
//add connection string
builder.Services.AddDbContext<FoodZoneContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FoodZoneCnn"));
});

//config identity
builder.Services.AddIdentity<Account, IdentityRole>(q =>
{
    q.Password.RequireDigit = true;
    q.Password.RequiredLength = 8;
    q.Password.RequireUppercase = true;
    q.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<FoodZoneContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication();

//add dependency injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

//add cors
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", bder => bder.AllowAnyOrigin()
                                                           .AllowAnyMethod()
                                                           .AllowAnyHeader());
});

//add automapper
builder.Services.AddAutoMapper(typeof(MapperInitializer));

//config api docs
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodZone", Version = "v1" }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
