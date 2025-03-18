using System.ComponentModel.DataAnnotations;
namespace api_peliculas.Models;

public class Categoría
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public DateTime FechaCreación { get; set; }
}
