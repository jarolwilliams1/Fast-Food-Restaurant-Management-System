using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
   

    public class ProductRepository : IProductsRepository
    {
        private readonly FastFoodManagerDBContext _context;

        public ProductRepository(FastFoodManagerDBContext context)
        {
            _context = context;
        }

        public async Task AgregarProductoAsync(Producto p)
        {
            try
            {
                _context.Productos.Add(p);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar producto: {ex.Message}");
            }
        }

        public async Task EliminarProductoAsync(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar producto: {ex.Message}");
            }
        }

        public async Task ActualizarProductoAsync(Producto p)
        {
            try
            {
                _context.Productos.Update(p);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar producto: {ex.Message}");
            }
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            try
            {
                return await _context.Productos.ToListAsync();
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
                return await _context.Productos
                    .Where(p => p.Disponible)
                    .OrderBy(p => p.Categoria)
                    .ThenBy(p => p.Nombre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos disponibles: {ex.Message}");
            }
        }

        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            try
            {
                return await _context.Productos.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener producto por ID: {ex.Message}");
            }
        }

        public async Task<List<Producto>> ObtenerProductosPorCategoriaAsync(string categoria)
        {
            try
            {
                return await _context.Productos
                    .Where(p => p.Categoria == categoria && p.Disponible)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos por categoría: {ex.Message}");
            }
        }
    }
}