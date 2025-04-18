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
                return false;

            _db.Pelicula.Remove(pelicula);
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> ExistePelicula(string nombre)
        {
            var existe = await _db.Pelicula.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
            return existe;
        }

        public async Task<PeliculaDto> GetPelicula(int id)
        {
            var pelicula = await _db.Pelicula.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<PeliculaDto>(pelicula);
        }

        public async Task<List<PeliculaDto>> GetPeliculas()
        {
            var peliculas = await _db.Pelicula.OrderBy(c => c.Nombre).ToListAsync();
            return _mapper.Map<List<PeliculaDto>>(peliculas);
        }
        public async Task<bool> PeliculaExists(int id)
        {
            var existe = await _db.Pelicula.AnyAsync(c => c.Id == id);
            return existe;
        }

        public async Task<List<PeliculaDto>> GetPeliculasEnCategoria(int idCategoria)
        {
            var peliculas = await _db.Pelicula
                .Where(c => c.CategoriaId == idCategoria)
                .ToListAsync();

            return _mapper.Map<List<PeliculaDto>>(peliculas);
        }
        public async Task<List<PeliculaDto>> GetPeliculaPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return [];
            }
            var peliculas = await _db.Pelicula
                .Where(c => EF.Functions.Like(c.Nombre, $"%{nombre}%"))
                .ToListAsync();

            return _mapper.Map<List<PeliculaDto>>(peliculas);
        }
    }
}
