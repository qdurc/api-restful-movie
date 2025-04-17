namespace api_peliculas.Repos
{
    using api_peliculas.Models;
    using api_peliculas.Data;
    using api_peliculas.Repos.IRepos;
    using api_peliculas.Models.Dtos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;

    public class PeliculaRepo : IPeliculaRepo
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public PeliculaRepo(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> ActualizarPelicula(PeliculaDto peliculaDto)
        {
            var peliculaExistente = await _db.Pelicula.FirstOrDefaultAsync(p => p.Id == peliculaDto.Id);
            if (peliculaExistente == null)
                return false;

            _mapper.Map(peliculaDto, peliculaExistente); // actualiza los campos sobre la entidad ya rastreada

            var cambios = await _db.SaveChangesAsync();
            return cambios > 0;
        }

        public async Task<PeliculaDto> CrearPelicula(CrearPeliculaDto crearPeliculaDto)
        {
            var pelicula = _mapper.Map<Pelicula>(crearPeliculaDto);
            pelicula.FechaCreacion = DateTime.Now;
            _db.Pelicula.Add(pelicula);
            await _db.SaveChangesAsync();
            return _mapper.Map<PeliculaDto>(pelicula);
        }

        public async Task<bool> EliminarPelicula(int id)
        {
            var pelicula = await _db.Pelicula.FirstOrDefaultAsync(c => c.Id == id);
            if (pelicula == null)
            {
                return false;
            }

            _db.Pelicula.Remove(pelicula);
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> ExistePelicula(string nombre)
        {
            var existe = _db.Pelicula.Any(c => c.Nombre.ToLower() == nombre.ToLower());
            return Task.FromResult(existe);
        }

        public Task<bool> ExisteClasificacion(Pelicula.Clasificacion clasificacion)
        {
            bool existe = _db.Pelicula.Any(p => p.ClasificacionPelicula == clasificacion);
            return Task.FromResult(existe);
        }

        public Task<PeliculaDto> GetPelicula(int id)
        {
            var pelicula = _db.Pelicula.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(_mapper.Map<PeliculaDto>(pelicula));
        }

        public async Task<List<PeliculaDto>> GetPeliculas()
        {
            var peliculas = await _db.Pelicula.OrderBy(c => c.Nombre).ToListAsync();
            return _mapper.Map<List<PeliculaDto>>(peliculas);
        }
        public Task<bool> PeliculaExists(int id)
        {
            var existe = _db.Pelicula.Any(c => c.Id == id);
            return Task.FromResult(existe);
        }
    }
}
