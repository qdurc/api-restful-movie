using AutoMapper;
using api_peliculas.Models;
using api_peliculas.Models.Dtos;

namespace api_peliculas.PeliculasMapper
{
    public class PeliculasMappers : Profile
    {
        public PeliculasMappers()
        {
            //Categorias
            CreateMap<Categoría, CategoriaDto>().ReverseMap();
            CreateMap<Categoría, CrearCategoriaDto>().ReverseMap();

            //Peliculas
            CreateMap<Pelicula, CrearPeliculaDto>().ReverseMap();
                    // Mapeo para actualizar película (PUT/PATCH) – se ignora FechaCreacion
            CreateMap<Pelicula, PeliculaDto>()
                .ReverseMap()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore());
        }
    }
}