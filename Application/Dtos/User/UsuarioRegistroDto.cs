using System.ComponentModel.DataAnnotations;

namespace api_peliculas.Application.Dtos
{
    public class UsuarioRegistroDto
    { 
        [Required(ErrorMessage = "El campo nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string Contrasena { get; set; }
        public string Role { get; set; }
    }
}