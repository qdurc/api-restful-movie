using Microsoft.EntityFrameworkCore;
using api_peliculas.Domain.Entities;
namespace api_peliculas.Infrastructure.Data;

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