namespace api_peliculas.Models.Dtos
{
    public class UsuarioLoginResDto
    {
        public UsuarioDatosDto Usuario { get; set; }
        public string Token { get; set; }
    }
}