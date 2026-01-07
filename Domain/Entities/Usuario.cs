using System.ComponentModel.DataAnnotations;
namespace api_peliculas.Domain.Entities;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Nombre { get; set; }
    public string Contrasena { get; set; }
    public string Role { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}