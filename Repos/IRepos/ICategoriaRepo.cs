namespace api_peliculas.Repos.IRepos;

public interface ICategoriaRepo
{
    // Metodo para crear traer las categorias
    IColection<Categoria> GetCategorias();
    // Metodo para seleccionar un categoria por id
    Categoria GetCategoria(int CategoriaId);
    // Metodo para validar si existe una categoria por id
    bool ExisteCategoria(int id);
    // Metodo para validar si existe una categoria por nombre
    bool ExisteCategoria(string nombre);


    
}

