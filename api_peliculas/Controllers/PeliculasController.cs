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
    }
}