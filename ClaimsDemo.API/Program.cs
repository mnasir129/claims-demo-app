var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapGet("/", (IConfiguration configuration, IWebHostEnvironment environment) =>
{
    var applicationName = configuration["ClaimsDemo:ApplicationName"] ?? "Claims Demo API";
    var message = configuration["ClaimsDemo:Message"] ?? "Hello from Claims Demo API";

    return Results.Ok(new
    {
        application = applicationName,
        message,
        environment = environment.EnvironmentName,
        version = "1.0.0"
    });
});

app.MapHealthChecks("/health");

app.Run();
