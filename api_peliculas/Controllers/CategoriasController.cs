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

        // GET: api/Categorias/5
        [HttpGet("{Id:int}", Name = "GetCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CategoriaDto> GetCategoria(int Id)
        {
            var categoria = _repo.GetCategoria(Id);
            if (categoria == null)
            {
                return NotFound();
            }
            var categoriaDTO = _mapper.Map<CategoriaDto>(categoria);
            return Ok(categoriaDTO);
        }
    }
}
