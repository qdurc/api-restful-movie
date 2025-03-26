using api_peliculas.Models;

namespace api_peliculas.Repos.IRepos;

public interface ICategoriaRepo
{
    // Metodo para crear traer las categorias
    ICollection<Categoría> GetCategorias();
    // Metodo para seleccionar un categoria por id
    Categoría GetCategoria(int CategoriaId);
    // Metodo para validar si existe una categoria por id
    bool ExisteCategoria(int id);
    // Metodo para validar si existe una categoria por nombre
    bool ExisteCategoria(string nombre);
    

    
}
