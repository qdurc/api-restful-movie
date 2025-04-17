namespace api_peliculas.Models.Dtos
{
    public class PeliculaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string ImageURL { get; set; }
        public string ClasificacionPelicula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CategoriaId { get; set; }
    }
}