namespace api_peliculas.Controllers
{
    using api_peliculas.Models;
    using api_peliculas.Repos.IRepos;
    using Microsoft.AspNetCore.Mvc;
    using api_peliculas.Models.Dtos;

    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepo _repo;
        public PeliculasController(IPeliculaRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PeliculaDto>>> GetPeliculas()
        {
            var peliculas = await _repo.GetPeliculas();
            return Ok(peliculas);
        }
        [HttpGet("{id:int}", Name = "GetPelicula")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeliculaDto>> GetPelicula(int id)
        {
            var pelicula = await _repo.GetPelicula(id);
            if (pelicula == null || pelicula.Id == 0)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PeliculaDto>> CrearPelicula([FromBody] CrearPeliculaDto crearPeliculaDto)
        {
            if (crearPeliculaDto == null)
            {
                return BadRequest(ModelState);
            }
            if (await _repo.ExistePelicula(crearPeliculaDto.Nombre))
            {
                ModelState.AddModelError("Error", "La película ya existe");
                return BadRequest(ModelState);
            }
            var pelicula = await _repo.CrearPelicula(crearPeliculaDto);
            return CreatedAtRoute("GetPelicula", new { id = pelicula.Id }, pelicula);
        }
        [HttpPatch("{id:int}", Name = "ActualizarPelicula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ActualizarPelicula(int id, [FromBody] PeliculaDto peliculaDto)
        {
            if (peliculaDto == null || id != peliculaDto.Id)
            {
                return BadRequest(ModelState);
            }
            if (await _repo.ExistePelicula(peliculaDto.Nombre))
            {
                ModelState.AddModelError("Error", "La película ya existe");
                return BadRequest(ModelState);
            }
            var pelicula = await _repo.GetPelicula(id);
            if (pelicula == null || pelicula.Id == 0)
            {
                return NotFound();
            }
            await _repo.ActualizarPelicula(peliculaDto);
            return NoContent();
        }
        [HttpDelete("{id:int}", Name = "EliminarPelicula")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido.");
            }

            var fueEliminada = await _repo.EliminarPelicula(id);
            if (!fueEliminada)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("GetPeliculasEnCategoria/{idCategoria:int}", Name = "GetPeliculasEnCategoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PeliculaDto>>> GetPeliculasEnCategoria(int idCategoria)
        {
            var peliculas = await _repo.GetPeliculasEnCategoria(idCategoria);
            if (peliculas == null || peliculas.Count == 0)
            {
                return NotFound();
            }
            return Ok(peliculas);
        }
        [HttpGet("Buscar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PeliculaDto>>> GetPeliculaPorNombre([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return BadRequest("El parámetro 'nombre' es requerido.");
            try
            {
                var peliculas = await _repo.GetPeliculaPorNombre(nombre);
                return peliculas.Any()
                    ? Ok(peliculas)
                    : NotFound("No se encontraron películas con ese nombre.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}