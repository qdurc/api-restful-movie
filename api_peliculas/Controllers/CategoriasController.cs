using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_peliculas.Models.Dtos;
using api_peliculas.Repos.IRepos;
using AutoMapper;
using api_peliculas.Models;

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

        // GET: api/Categorias/{Id}
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
        // POST: api/Categorias
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CrearCategoriaDto> CrearCategoria([FromBody] CrearCategoriaDto crearCategoriaDto)
        {
            if (crearCategoriaDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_repo.ExisteCategoria(crearCategoriaDto.Nombre))
            {
                ModelState.AddModelError("Nombre", "La categoria ya existe!");
                return BadRequest(ModelState);
            }
            var categoria = _mapper.Map<Categoría>(crearCategoriaDto);
            if (!_repo.CrearCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal al guardar el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCategoria", new { Id = categoria.Id }, categoria);
        }

        // PATCH: api/Categorias/{Id}
        [HttpPatch("{Id:int}", Name = "ActualizarCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ActualizarCategoria(int Id, [FromBody] CategoriaDto categoriaDto)
        {
            if (categoriaDto == null || Id != categoriaDto.Id || !ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Los datos enviados no son correctos!");
                return BadRequest(ModelState);
            }
            var categoria = _mapper.Map<Categoría>(categoriaDto);
            if (_repo.ExisteCategoria(categoria.Nombre))
            {
                ModelState.AddModelError("Nombre", "La categoria ya existe!");
                return BadRequest(ModelState);
            }
            if (!_repo.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal al actualizar el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        // DELETE: api/Categorias/{Id}
        [HttpDelete("{Id:int}", Name = "DelCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DelCategoria(int Id)
        {
            var existe = _repo.ExisteCategoria(Id);
            if (!existe)
            {
                ModelState.AddModelError("Error", "El ID de la categoria no existe!");
                return BadRequest(ModelState);
            }
            var categoria = _repo.GetCategoria(Id);
            if (!_repo.EliminarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal al eliminar el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
