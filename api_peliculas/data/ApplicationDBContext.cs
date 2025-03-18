using Microsoft.EntityFrameworkCore;
namespace api_pelicualas.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    // DbSet for the Categoría model
    public DbSet<api_peliculas.Models.Categoría> Categorías { get; set; }

}