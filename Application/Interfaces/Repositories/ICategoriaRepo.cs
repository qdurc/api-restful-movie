using api_peliculas.Domain.Entities;

namespace api_peliculas.Application.Interfaces.Repositories;

public interface ICategoriaRepo
{
    //CRUD
    // Metodo para traer las categorias
    ICollection<Categoría> GetCategorias();
    // Metodo para seleccionar un categoria por id
    Categoría GetCategoria(int CategoriaId);
    // Metodo para validar si existe una categoria por id
    bool ExisteCategoria(int id);
    // Metodo para validar si existe una categoria por nombre
    bool ExisteCategoria(string nombre);
    //Metodo para crear una categoria
    bool CrearCategoria(Categoría categoria);
    //Metodo para actualizar una categoria
    bool ActualizarCategoria(Categoría categoria);
    //Metodo para eliminar una categoria
    bool EliminarCategoria(Categoría categoría);
    // Metodo para guardar los cambios
    bool Guardar();
}
