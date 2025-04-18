using api_peliculas.Models.Dtos;

namespace api_peliculas.Repos.IRepos
{
    public interface IPeliculaRepo
    {
        Task<List<PeliculaDto>> GetPeliculas();
        Task<PeliculaDto> GetPelicula(int id);
        Task<List<PeliculaDto>> GetPeliculasEnCategoria(int idCategoria);
        Task<PeliculaDto> CrearPelicula(CrearPeliculaDto crearPeliculaDto);
        Task<bool> PeliculaExists(int id);
        Task<bool> ExistePelicula(string nombre);
        Task<bool> ActualizarPelicula(PeliculaDto peliculaDto);
        Task<bool> EliminarPelicula(int id);
    }
}