using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using PCStore.DAL.Repositories.Contracts;
using PCStore.DAL.Repositories;
using PCStore.DAL.Persistence;
using PCStore.DAL.Caching.RedisCache;
using PCStore.API.Middleware;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("PCStore.DAL")));

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Authorization
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("OnlyAdmin", policyBuilder => policyBuilder.RequireClaim("UserRole", "Administrator"));
    option.AddPolicy("OnlyUser", policyBuilder => policyBuilder.RequireClaim("UserRole", "User"));
});

// Persistence
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddSingleton<Serilog.ILogger>(sp => Log.Logger);

// MediatR
var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(currentAssemblies));

//AddingServices
builder.Services.AddScoped<IRedisCacheService,RedisCacheService>();
builder.Services.AddScoped<ILoggerService,LoggerService>();

//Adding Cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "rediscache:6379";
    options.InstanceName = "PCStore";

});

builder.Services.AddEndpointsApiExplorer();


//Adding CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

//Adding Swagger Authorization
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PCStore API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();

        context.SeedData();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowOrigin");

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();