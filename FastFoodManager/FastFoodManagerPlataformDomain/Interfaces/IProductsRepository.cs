using FastFoodManagerPlataformDomain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodManagerPlataformDomain.Interfaces
{
    public interface IProductsRepository
    {
        Task AgregarProductoAsync(Producto p);
        Task EliminarProductoAsync(int id);
        Task ActualizarProductoAsync(Producto p);
        Task<List<Producto>> ObtenerProductosAsync();
        Task<List<Producto>> ObtenerProductosDisponiblesAsync();
        Task<Producto> ObtenerProductoPorIdAsync(int id);
        Task<List<Producto>> ObtenerProductosPorCategoriaAsync(string categoria);
    }
}
