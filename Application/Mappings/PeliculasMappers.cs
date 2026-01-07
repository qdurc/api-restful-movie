using AutoMapper;
using api_peliculas.Domain.Entities;
using api_peliculas.Application.Dtos;

namespace api_peliculas.Application.Mappings
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
            // Mapeo para actualizar película (PATCH) – se ignora FechaCreacion
            CreateMap<Pelicula, PeliculaDto>()
                .ReverseMap()
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore());
        }
    }
}