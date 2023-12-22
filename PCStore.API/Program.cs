using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccess.DbContexts;
using DataAccess.Repositories.Contracts;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MassTransit;
using MassTransit.Definition;
using PCStore.API.Seeding;
using PCStore.API.Consumers;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Set up JWT Bearer authentication in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
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

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("odneivkdivrenekjwjfdw8232jene")),
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddDbContext<PCStoreDbContext>(options =>
{
    var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbname = Environment.GetEnvironmentVariable("DB_NAME");
    var dbpass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");


    string connectionString = $"Data Source={dbhost};User ID=sa;Password={dbpass};Initial Catalog={dbname};Encrypt=True;Trust Server Certificate=True;";
    options.UseSqlServer(connectionString, b => 
    {
        b.MigrationsAssembly("PCStoreService.API");
        b.EnableRetryOnFailure();
    });
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis-cache:6379";
    options.InstanceName = "PCStore";

});

builder.Services.AddScoped<IEFTypesRepository, EFTypesRepository>();
builder.Services.AddScoped<IEFBrandsRepository, EFBrandsRepository>();
builder.Services.AddScoped<IEFCommentsRepository, EFCommentRepository>();
builder.Services.AddScoped<IEFOrdersRepository, EFOrdersRepository>();
builder.Services.AddScoped<IEFPartOrdersRepository, EFPartOrdersRepository>();
builder.Services.AddScoped<IEFProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IEFStatusesRepository, EFStatusesRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

builder.Services.AddSingleton<IUserState,UserState>();
builder.Services.AddSingleton<UserConsumer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
DbSeeding.Seed(app);

app.Run();