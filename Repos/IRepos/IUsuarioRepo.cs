using api_peliculas.Models;
using api_peliculas.Models.Dtos;

namespace api_peliculas.Repos.IRepos
{
    public interface IUsuarioRepo
    {
        Task<List<UsuarioDto>> GetUsuarios();
        Task<UsuarioDto> GetUsuario(int id);
        Task<UsuarioDto> GetUsuario(string nombreUsuario);
        Task<UsuarioLoginResDto> Login(UsuarioLoginDto usuarioLoginDto);
        Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto);
        Task<bool> IsUniqueUser(string nombreUsuario);
    }
}
