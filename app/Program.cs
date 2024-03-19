using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Users.Model;
using Seed.Data;
using Iniciatives.Model;

var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Establece la ruta base para buscar el archivo appsettings.json
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Carga el archivo appsettings.json

IConfiguration Configuration = config.Build();

var mongoClient = new MongoClient(Configuration["MongoDbSettings:ConnectionString"]);
var database = mongoClient.GetDatabase("Caso");
builder.Services.AddSingleton<IMongoDatabase>(database);

var users = database.GetCollection<User>("Users");
var iniciatives = database.GetCollection<Iniciative>("Iniciatives");


if (users.EstimatedDocumentCount() == 0)
{
    users.InsertMany(SeedData.Users);
    Console.WriteLine("Datos sembrados exitosamente.");
}
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
