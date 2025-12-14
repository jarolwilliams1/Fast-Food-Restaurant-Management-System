using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{
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

    public class ProductoService : IProductoService
    {
        private readonly IProductsRepository _productRepository;

        public ProductoService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Producto>> ObtenerTodosProductosAsync()
        {
            try
            {
                return await _productRepository.ObtenerProductosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos: {ex.Message}");
            }
        }

        public async Task<List<Producto>> ObtenerProductosDisponiblesAsync()
        {
            try
            {
                return await _productRepository.ObtenerProductosDisponiblesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos disponibles: {ex.Message}");
            }
        }

        public async Task<List<Producto>> ObtenerProductosPorCategoriaAsync(string categoria)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoria))
                    throw new ArgumentException("La categoría no puede estar vacía");

                return await _productRepository.ObtenerProductosPorCategoriaAsync(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos por categoría: {ex.Message}");
            }
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("El ID debe ser mayor a cero");

                var producto = await _productRepository.ObtenerProductoPorIdAsync(id);

                if (producto == null)
                    throw new Exception($"No se encontró el producto con ID {id}");

                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener producto: {ex.Message}");
            }
        }

        public async Task<bool> AgregarProductoAsync(string nombre, string categoria, decimal precio, string descripcion, bool disponible)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre no puede estar vacío");

                if (precio <= 0)
                    throw new ArgumentException("El precio debe ser mayor a cero");

                var producto = new Producto
                {
                    Nombre = nombre.Trim(),
                    Categoria = categoria?.Trim(),
                    Precio = precio,
                    Descripcion = descripcion?.Trim(),
                    Disponible = disponible
                };

                await _productRepository.AgregarProductoAsync(producto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar producto: {ex.Message}");
            }
        }

        public async Task<bool> ActualizarProductoAsync(int id, string nombre, string categoria, decimal precio, string descripcion, bool disponible)
        {
            try
            {
                // Validaciones
                if (id <= 0)
                    throw new ArgumentException("El ID debe ser mayor a cero");

                if (string.IsNullOrWhiteSpace(nombre))
                    throw new ArgumentException("El nombre no puede estar vacío");

                if (precio <= 0)
                    throw new ArgumentException("El precio debe ser mayor a cero");

                var producto = await _productRepository.ObtenerProductoPorIdAsync(id);

                if (producto == null)
                    throw new Exception($"No se encontró el producto con ID {id}");

                producto.Nombre = nombre.Trim();
                producto.Categoria = categoria?.Trim();
                producto.Precio = precio;
                producto.Descripcion = descripcion?.Trim();
                producto.Disponible = disponible;

                await _productRepository.ActualizarProductoAsync(producto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar producto: {ex.Message}");
            }
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("El ID debe ser mayor a cero");

                var producto = await _productRepository.ObtenerProductoPorIdAsync(id);

                if (producto == null)
                    throw new Exception($"No se encontró el producto con ID {id}");

                await _productRepository.EliminarProductoAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto: {ex.Message}");
            }
        }

        public async Task<bool> CambiarDisponibilidadAsync(int id, bool disponible)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("El ID debe ser mayor a cero");

                var producto = await _productRepository.ObtenerProductoPorIdAsync(id);

                if (producto == null)
                    throw new Exception($"No se encontró el producto con ID {id}");

                producto.Disponible = disponible;
                await _productRepository.ActualizarProductoAsync(producto);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar disponibilidad: {ex.Message}");
            }
        }

        public async Task<List<string>> ObtenerCategoriasAsync()
        {
            try
            {
                var productos = await _productRepository.ObtenerProductosAsync();
                var categorias = productos
                    .Select(p => p.Categoria)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();

                return categorias;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener categorías: {ex.Message}");
            }
        }
    }
}
