using api_peliculas.Application.Dtos;

namespace api_peliculas.Application.Interfaces.Repositories
{
    public interface IPeliculaRepo
    {
        Task<List<PeliculaDto>> GetPeliculas();
        Task<PeliculaDto> GetPelicula(int id);
        Task<List<PeliculaDto>> GetPeliculaPorNombre(string nombre);
        Task<List<PeliculaDto>> GetPeliculasEnCategoria(int idCategoria);
        Task<PeliculaDto> CrearPelicula(CrearPeliculaDto crearPeliculaDto);
        Task<bool> PeliculaExists(int id);
        Task<bool> ExistePelicula(string nombre);
        Task<bool> ActualizarPelicula(PeliculaDto peliculaDto);
        Task<bool> EliminarPelicula(int id);
    }
}