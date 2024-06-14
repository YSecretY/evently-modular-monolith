using Evently;
using Evently.Extensions;
using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Users.Infrastructure;
using Evently.Shared.Application;
using Evently.Shared.Infrastructure;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = builder.Configuration.GetConnectionString("Database")
                               ?? throw new NullReferenceException("Database connection string is not found.");

var redisConnectionString = builder.Configuration.GetConnectionString("Cache")
                            ?? throw new NullReferenceException("Cache connection string is not found.");

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddSharedApplication([
    Evently.Modules.Events.Application.AssemblyReference.Assembly,
    Evently.Modules.Users.Application.AssemblyReference.Assembly
]);

builder.Services.AddSharedInfrastructure(databaseConnectionString, redisConnectionString);

builder.Configuration.AddModulesConfigurations(["Events", "Users"]);

builder.Services.AddEventsModule(builder.Configuration);
builder.Services.AddUsersModule(builder.Configuration);

builder.Services.AddHealthChecks()
    .AddNpgSql(databaseConnectionString)
    .AddRedis(redisConnectionString);

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

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();