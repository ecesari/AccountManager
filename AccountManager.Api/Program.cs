using AccountManager.Api.ServiceCollections;
using AccountManager.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using AccountManager.Application.Accounts.Commands.CreateAccount;
using AccountManager.Api.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = " Account Manager API"
    });
});

builder.Services.AddDbContext<AccountManagerDbContext>(options => options.UseInMemoryDatabase("AccountDb"));
builder.Services.AddRepositories();
builder.Services.AddAutoMapper();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateAccountCommand).Assembly));


builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<LoggerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
