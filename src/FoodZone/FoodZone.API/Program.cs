using FoodZone.API.Configurations;
using FoodZone.Data;
using FoodZone.Data.Infrastructure;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
//config log
//builder.Host.UseSerilog();
//Log.Logger = new LoggerConfiguration()
//    .WriteTo
//    .File(path: "logs\\log-.txt",
//    outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3} {Message:lj}{NewLine}{Exception}]",
//    rollingInterval: RollingInterval.Day,
//    restrictedToMinimumLevel: LogEventLevel.Information).CreateLogger();

// Add services to the container.
//add connection string
builder.Services.AddDbContext<FoodZoneContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FoodZoneCnn"));
});

builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(Configuration);

//add dependency injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFoodServices, FoodServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<IReservationServices, ReservationServices>();
builder.Services.AddScoped<IReservationDetailServices, ReservationDetailServices>();
builder.Services.AddScoped<IMenuServices, MenuServices>();
builder.Services.AddScoped<ISalaryServices, SalaryServices>();
builder.Services.AddScoped<ITableServices, TableServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

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
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
        Enter 'Bearer' [space] and then your token in the text input below.
        Example: 'Bearer 12345abcdef",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "0auth2",
            Name = "Bearer",
            In = ParameterLocation.Header
            },
            new List<string>()
    }});

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FoodZone", Version = "v1" });
});

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
