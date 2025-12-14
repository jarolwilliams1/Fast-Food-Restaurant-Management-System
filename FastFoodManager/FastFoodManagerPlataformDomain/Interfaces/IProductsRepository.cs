using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;

namespace FastFoodPlataformPersistencia.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Producto>> ObtenerProductosAsync();
        Task<List<Producto>> ObtenerProductosDisponiblesAsync();
        Task<List<Producto>> ObtenerProductosPorCategoriaAsync(string categoria);
        Task<Producto> ObtenerProductoPorIdAsync(int id);
        Task AgregarProductoAsync(Producto producto);
        Task ActualizarProductoAsync(Producto producto);
        Task EliminarProductoAsync(int id);
    }
}
