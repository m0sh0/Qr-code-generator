// Creates new configuration and DI container

using QrCodeGeneratorProject.Factory;
using QrCodeGeneratorProject.Factory.Interfaces;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); // Adds support for controllers and opens access to [ApiController] and [Route] attributes

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IQrCodeFactory, QrCodeFactory>(); // Allows me to inject QrCodeFactory into my controllers
WebApplication app = builder.Build(); // Creates and configures app

if (app.Environment.IsDevelopment()) // If I'm in development mode, it creates a swagger UI for API testing
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

app.UseAuthorization(); // Enables middleware for authorization

app.MapControllers(); // Creates routes for my controllers like [Route("api/controller")]


app.Run(); // Starts the app