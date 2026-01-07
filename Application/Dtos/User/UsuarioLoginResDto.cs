namespace api_peliculas.Application.Dtos
{
    public class UsuarioLoginResDto
    {
        public UsuarioDatosDto Usuario { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}