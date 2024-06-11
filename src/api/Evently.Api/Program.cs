using Evently;
using Evently.Extensions;
using Evently.Modules.Event.Application;
using Evently.Modules.Event.Infrastructure;
using Evently.Shared.Application;
using Evently.Shared.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSharedApplication([AssemblyReference.Assembly]);

builder.Services.AddSharedInfrastructure(
    builder.Configuration.GetConnectionString("DbConnection") ?? throw new NullReferenceException("Connection string is not found.")
);

builder.Configuration.AddModulesConfigurations(["Events"]);

builder.Services.AddEventsModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();