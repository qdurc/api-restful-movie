namespace api_peliculas.Repos
{
    using api_peliculas.Models;
    using api_peliculas.Data;
    using api_peliculas.Repos.IRepos;
    using api_peliculas.Models.Dtos;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using System.Security.Cryptography;
    using System.Text;

    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public UsuarioRepo(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> GetUsuario(int id)
        {
            var user = await _db.Usuario.FirstOrDefaultAsync(c => c.Id == id);
            if (user == null)
                return null;
            return _mapper.Map<UsuarioDto>(user);
        }

        public async Task<UsuarioDto> GetUsuario(string nombreUsuario)
        {
            var user = await _db.Usuario.FirstOrDefaultAsync(c => c.NombreUsuario.ToLower() == nombreUsuario.ToLower());
            if (user == null)
                return null;
            return _mapper.Map<UsuarioDto>(user);
        }

        public Task<List<UsuarioDto>> GetUsuarios()
        {
            var user = _db.Usuario.ToList();
            if (user == null)
                return null;
            return Task.FromResult(_mapper.Map<List<UsuarioDto>>(user));
        }

        public async Task<bool> IsUniqueUser(string nombreUsuario)
        {
            var nombre = nombreUsuario.Trim().ToLower();
            return !await _db.Usuario.AnyAsync(u => u.NombreUsuario.ToLower().Trim() == nombre);
        }

        public Task<UsuarioLoginResDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegistroDto)
        {
            var passwordEncr = obtenermd5(usuarioRegistroDto.Contrasena);

            Usuario usuario = new Usuario()
            {
                NombreUsuario = usuarioRegistroDto.NombreUsuario,
                Nombre = usuarioRegistroDto.Nombre,
                Contrasena = passwordEncr,
                Role = usuarioRegistroDto.Role
            };
            _db.Usuario.Add(usuario);
            await _db.SaveChangesAsync();
            usuario.Contrasena = passwordEncr;
            return usuario;
        }
        public static string obtenermd5(string valor)
        {
            if (valor == null)
                valor = string.Empty;
            using var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(valor);
            var hashBytes = md5.ComputeHash(inputBytes);
            var builder = new StringBuilder(hashBytes.Length * 2);
            foreach (var b in hashBytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
