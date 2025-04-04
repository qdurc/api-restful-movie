using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_peliculas.Models.Dtos;
using api_peliculas.Repos.IRepos;
using AutoMapper;

namespace api_peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepo _repo;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: api/Categorias
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<CategoriaDto>> GetCategorias()
        {
            var categorias = _repo.GetCategorias();
            var categoriasDTO = _mapper.Map<List<CategoriaDto>>(categorias);
            return Ok(categoriasDTO);
        }




    }
}
