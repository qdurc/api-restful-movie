using Microsoft.EntityFrameworkCore;
using api_peliculas.Models;
namespace api_peliculas.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    // DbSet for the Categoría model
    public DbSet<Categoría> Categoría { get; set; }

}