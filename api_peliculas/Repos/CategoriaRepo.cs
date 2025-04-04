using api_peliculas.Repos.IRepos;
using api_peliculas.Models;
using api_peliculas.Data;

namespace api_peliculas.Repos;
public class CategoriaRepo : ICategoriaRepo
{
    private readonly ApplicationDBContext _db;
    public CategoriaRepo(ApplicationDBContext db)
    {
        _db = db;
    }
    public ICollection<Categoría> GetCategorias()
    {
        return _db.Categoría.OrderBy(c => c.Nombre).ToList();
    }
    public Categoría GetCategoria(int id)
    {
        return _db.Categoría.FirstOrDefault(c => c.Id == id);
    }
    public bool ExisteCategoria(int id)
    {
        return _db.Categoría.Any(c => c.Id == id);
    }
    public bool ExisteCategoria(string nombre)
    {
        //Eliminamos los espacios en blanco y lo convertimos a minusculas
        return _db.Categoría.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
    }
    public bool CrearCategoria(Categoría categoría)
    {
        categoría.FechaCreación = DateTime.Now;
        _db.Categoría.Add(categoría);
        return Guardar();
    }
    public bool ActualizarCategoria(Categoría categoría)
    {
        categoría.FechaCreación = DateTime.Now;
        _db.Categoría.Update(categoría);
        return Guardar();
    }
    public bool EliminarCategoria(Categoría categoría)
    {
        _db.Categoría.Remove(categoría);
        return Guardar();
    }
    public bool Guardar()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }
}