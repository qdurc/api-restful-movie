using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Models.Dtos
{
    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(60, ErrorMessage = "El campo nombre no puede tener más de 60 caracteres")]
        public string Nombre { get; set; }
    }
}