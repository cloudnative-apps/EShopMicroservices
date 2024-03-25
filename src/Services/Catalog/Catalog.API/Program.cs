using BuildingBlocks;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// If needed, Clear default providers
builder.Logging.ClearProviders();

// Use Serilog
//builder.Host.UseSerilog((hostContext, services, configuration) => {
//    configuration
//        .WriteTo.File("serilog-file.txt")
//        .WriteTo.Console();
//});

builder.Host.UseSerilog(Logging.ConfigureLogger);


var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

//builder.Services.AddMediatR(config=>
//{
//    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
//});

builder.Services.AddCarter();


builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

//builder.Services.AddHealthChecks()
//    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapCarter();

app.UseExceptionHandler(options => { });


app.Run();
