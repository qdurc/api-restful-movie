namespace api_peliculas.Models.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}