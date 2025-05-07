using System.ComponentModel.DataAnnotations;
namespace api_peliculas.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Nombre { get; set; }
    public string Contrasena { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}