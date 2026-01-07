using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Application.Dtos
{
    public class UsuarioLoginDto
    { 
        [Required(ErrorMessage = "El campo nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string Contrasena { get; set; }
    }
}