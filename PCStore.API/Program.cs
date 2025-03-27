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
using PCStore.DAL;
using PCStore.DAL.Infrastructure.Interfaces;
using PCStore.DAL.Infrastructure;
using PCStore.DAL.Repositories.Contracts;
using PCStore.DAL.Repositories;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Services;

var builder = WebApplication.CreateBuilder(args);

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

//Adding Repositories
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICharacteristicsRepository, CharacteristicsRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IContragentDescriptionRepository, ContragentDescriptionRepository>();
builder.Services.AddScoped<IContragentRepository, ContragentRepository>();
builder.Services.AddScoped<ICountManipulationRepository, CountManipulationRepository>();
builder.Services.AddScoped<ICountOperationRepository, CountOperationRepository>();
builder.Services.AddScoped<ICountRepository, CountRepository>();
builder.Services.AddScoped<IDeliverAddressRepository, DeliverAddressRepository>();
builder.Services.AddScoped<IDeliverOptionRepository, DeliverOptionRepository>();
builder.Services.AddScoped<IInventarizationRepository, InventarizationRepository>();
builder.Services.AddScoped<IManipulationRepository, ManipulationRepository>();
builder.Services.AddScoped<INakladnaTypeRepository, NakladnaTypeRepository>();
builder.Services.AddScoped<INakladniProductsRepository, NakladniProductsRepository>();
builder.Services.AddScoped<INakladniRepository, NakladniRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
builder.Services.AddScoped<IPhotosRepository, PhotosRepository>();
builder.Services.AddScoped<IProductCharacteristicsRepository, ProductCharacteristicsRepository>();
builder.Services.AddScoped<IProductInventarizationRepository, ProductInventarizationRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductRestorageRepository, ProductRestorageRepository>();
builder.Services.AddScoped<IProductStoragesRepository, ProductStoragesRepository>();
builder.Services.AddScoped<IRestorageRepository, RestorageRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStorageRepository, StorageRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//AddingServices
builder.Services.AddScoped<IProductsService,ProductService>();

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

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();