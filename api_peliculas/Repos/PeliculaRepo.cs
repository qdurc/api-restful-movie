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
            peliculaDto.FechaCreacion = DateTime.Now;
            var pelicula = _mapper.Map<Pelicula>(peliculaDto);
            _db.Pelicula.Update(pelicula);
            return await Guardar();
        }

        public Task<PeliculaDto> CrearPelicula(CrearPeliculaDto crearPeliculaDto)
        {
            var pelicula = _mapper.Map<Pelicula>(crearPeliculaDto);
            _db.Pelicula.Add(pelicula);
            return Task.FromResult(_mapper.Map<PeliculaDto>(pelicula));
        }

        public Task<bool> EliminarPelicula(int id)
        {
            var pelicula = _db.Pelicula.FirstOrDefault(c => c.Id == id);
            if (pelicula != null)
            {
                _db.Pelicula.Remove(pelicula);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> ExistePelicula(string nombre)
        {
            var existe = _db.Pelicula.Any(c => c.Nombre.ToLower() == nombre.ToLower());
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
        public async Task<bool> Guardar()
        {
            return await _db.SaveChangesAsync() >= 0;
        }

        public Task<bool> PeliculaExists(int id)
        {
            var existe = _db.Pelicula.Any(c => c.Id == id);
            return Task.FromResult(existe);
        }
    }
}
