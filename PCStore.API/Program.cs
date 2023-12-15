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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserConsumer>();
    x.UsingRabbitMq((ctx, cfg) =>
    {
        var uri = new Uri("rabbitmq://rabbitmq/");
        cfg.Host(uri, host =>
        {
            host.Username("user");
            host.Password("mypass");
        });
        cfg.ReceiveEndpoint("UserPublisher", c =>
        {
            c.ConfigureConsumer<UserConsumer>(ctx);
        });
    });
});
builder.Services.AddMassTransitHostedService();

builder.Services.AddAuthentication();

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

builder.Services.AddScoped<IEFTypesRepository, EFTypesRepository>();
builder.Services.AddScoped<IEFBrandsRepository, EFBrandsRepository>();
builder.Services.AddScoped<IEFCommentsRepository, EFCommentRepository>();
builder.Services.AddScoped<IEFOrdersRepository, EFOrdersRepository>();
builder.Services.AddScoped<IEFPartOrdersRepository, EFPartOrdersRepository>();
builder.Services.AddScoped<IEFProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IEFStatusesRepository, EFStatusesRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

builder.Services.AddSingleton<IUserState,UserState>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
DbSeeding.Seed(app);

app.Run();