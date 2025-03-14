using Scalar.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(); // Configura la generación de OpenAPI

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
