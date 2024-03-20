using MongoDB.Driver;
using WebApiCaso.Models;
using Seed.Data;
using WebApiCaso.Services;
var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // Establece la ruta base para buscar el archivo appsettings.json
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Carga el archivo appsettings.json

IConfiguration Configuration = config.Build();

var mongoClient = new MongoClient(Configuration["MongoDbSettings:ConnectionString"]);
var database = mongoClient.GetDatabase("Caso");
builder.Services.AddSingleton<IMongoDatabase>(database);

// Colecciones
var users = database.GetCollection<User>("Users");
var iniciatives = database.GetCollection<Iniciative>("Iniciatives");

// Añadir seed

if (users.EstimatedDocumentCount() == 0)
{
    users.InsertMany(SeedData.Users);
    Console.WriteLine("Datos sembrados exitosamente.");
}

// Añadir Serivicios
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IniciativeService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
