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
using PCStoreService.API.Settings;
using MassTransit.Definition;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x => 
{
    x.UsingRabbitMq((context, configurator) =>
    {
        var rabbitMQSettings=builder.Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
        configurator.Host(rabbitMQSettings.Host);
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("PCStoreService", false));
    });
});
builder.Services.AddMassTransitHostedService();

builder.Services.AddAuthentication();


builder.Services.AddDbContext<PCStoreDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("PCStoreService.API"));
});

builder.Services.AddScoped<IEFTypesRepository, EFTypesRepository>();
builder.Services.AddScoped<IEFBrandsRepository, EFBrandsRepository>();
builder.Services.AddScoped<IEFCommentsRepository, EFCommentRepository>();
builder.Services.AddScoped<IEFOrdersRepository, EFOrdersRepository>();
builder.Services.AddScoped<IEFPartOrdersRepository, EFPartOrdersRepository>();
builder.Services.AddScoped<IEFProductsRepository, EFProductsRepository>();
builder.Services.AddScoped<IEFStatusesRepository, EFStatusesRepository>();
builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();






var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();