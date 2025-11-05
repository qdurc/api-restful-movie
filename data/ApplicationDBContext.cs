using Microsoft.EntityFrameworkCore;
using api_peliculas.Models;
namespace api_peliculas.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    // DbSet for models
    public DbSet<Categoría> Categoría { get; set; }
    public DbSet<Pelicula> Pelicula { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

}