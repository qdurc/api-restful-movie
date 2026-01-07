using api_peliculas.Domain.Entities;
using api_peliculas.Application.Dtos;

namespace api_peliculas.Application.Interfaces.Repositories
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
