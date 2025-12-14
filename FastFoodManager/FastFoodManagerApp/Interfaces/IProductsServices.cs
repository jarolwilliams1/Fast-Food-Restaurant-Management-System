using FastFoodManagerPlataformDomain.Entites;

public interface IProductoService
{
    Task<List<Producto>> ObtenerTodosProductosAsync();
    Task<List<Producto>> ObtenerProductosDisponiblesAsync();
    Task<List<Producto>> ObtenerProductosPorCategoriaAsync(string categoria);
    Task<Producto> ObtenerProductoPorIdAsync(int id);
    Task<bool> AgregarProductoAsync(string nombre, string categoria, decimal precio, string descripcion, bool disponible);
    Task<bool> ActualizarProductoAsync(int id, string nombre, string categoria, decimal precio, string descripcion, bool disponible);
    Task<bool> EliminarProductoAsync(int id);
    Task<bool> CambiarDisponibilidadAsync(int id, bool disponible);
    Task<List<string>> ObtenerCategoriasAsync();
}
