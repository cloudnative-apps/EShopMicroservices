using BuildingBlocks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
// Addd serilog
builder.Logging.ClearProviders();
builder.Host.UseSerilog(Logging.ConfigureLogger);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
