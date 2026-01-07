using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Application.Dtos
{
    public class CrearPeliculaDto
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "El campo nombre no puede tener más de 60 caracteres")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string ImageURL { get; set; }
        public string ClasificacionPelicula { get; set; }
        public int CategoriaId { get; set; }
    }
}