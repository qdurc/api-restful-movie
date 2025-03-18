using Scalar.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using api_pelicualas.Data;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // Configura la generación de OpenAPI
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Configura la conexión a la base de datos

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
