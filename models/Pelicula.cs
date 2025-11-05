using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace api_peliculas.Models;

public class Pelicula
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; }
    public string ImageURL { get; set; }
    public enum Clasificacion { G, PG, PG13, R, NC17 }
    public Clasificacion ClasificacionPelicula { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int CategoriaId { get; set; }
    //FK con categoría
    [ForeignKey("Categoria")]
    public Categoría Categoría { get; set; }
}
