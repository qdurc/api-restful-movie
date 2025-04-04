using AutoMapper;
using api_peliculas.Models;
using api_peliculas.Models.Dtos;

namespace api_peliculas.PeliculasMapper
{
    public class PeliculasMappers : Profile
    {
        public PeliculasMappers()
        {
            CreateMap<Categoría, CategoriaDto>().ReverseMap();
            CreateMap<Categoría, CrearCategoriaDto>().ReverseMap();
        }
    }
}