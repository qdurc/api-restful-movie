using Scalar.AspNetCore;
using api_peliculas.Application.Interfaces.Repositories;
using api_peliculas.Infrastructure.Repositories;
using api_peliculas.Application.Mappings;
using api_peliculas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del .env en tiempo de ejecución
Env.Load();

// Leer la cadena de conexión del entorno
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

// Agrega servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); 

// Agrega servicios de inyección de dependencias
builder.Services.AddScoped<ICategoriaRepo, CategoriaRepo>();
builder.Services.AddScoped<IPeliculaRepo, PeliculaRepo>();

//Agrega servicios de AutoMapper
builder.Services.AddAutoMapper(typeof(PeliculasMappers));

var app = builder.Build();

// Configura el middleware de la aplicación
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Mapea el documento OpenAPI
    app.MapScalarApiReference(); // Mapea la interfaz de Scalar
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
