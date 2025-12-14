using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
  

    public class PromocionRepository : IPromocionRepository
    {
        private readonly FastFoodManagerDBContext _context;

        public PromocionRepository(FastFoodManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Promocione>> ObtenerTodasPromocionesAsync()
        {
            try
            {
                return await _context.Promociones
                    .Include(p => p.PromocionProductos)
                        .ThenInclude(pp => pp.Producto)
                    .OrderByDescending(p => p.Activa)
                    .ThenBy(p => p.Nombre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener promociones: {ex.Message}");
            }
        }

        public async Task<List<Promocione>> ObtenerPromocionesActivasAsync()
        {
            try
            {
                return await _context.Promociones
                    .Include(p => p.PromocionProductos)
                        .ThenInclude(pp => pp.Producto)
                    .Where(p => p.Activa)
                    .OrderBy(p => p.Nombre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener promociones activas: {ex.Message}");
            }
        }

        public async Task<List<Promocione>> ObtenerPromocionesPorTipoAsync(string tipo)
        {
            try
            {
                return await _context.Promociones
                    .Include(p => p.PromocionProductos)
                        .ThenInclude(pp => pp.Producto)
                    .Where(p => p.Tipo == tipo)
                    .OrderByDescending(p => p.Activa)
                    .ThenBy(p => p.Nombre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener promociones por tipo: {ex.Message}");
            }
        }

        public async Task<Promocione> ObtenerPromocionPorIdAsync(int id)
        {
            try
            {
                return await _context.Promociones
                    .Include(p => p.PromocionProductos)
                        .ThenInclude(pp => pp.Producto)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener promoción: {ex.Message}");
            }
        }

        public async Task AgregarPromocionAsync(Promocione promocion)
        {
            try
            {
                _context.Promociones.Add(promocion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar promoción: {ex.Message}");
            }
        }

        public async Task ActualizarPromocionAsync(Promocione promocion)
        {
            try
            {
                _context.Promociones.Update(promocion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar promoción: {ex.Message}");
            }
        }

        public async Task EliminarPromocionAsync(int id)
        {
            try
            {
                var promocion = await _context.Promociones.FindAsync(id);
                if (promocion != null)
                {
                    _context.Promociones.Remove(promocion);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar promoción: {ex.Message}");
            }
        }

        public async Task CambiarEstadoPromocionAsync(int id, bool activa)
        {
            try
            {
                var promocion = await _context.Promociones.FindAsync(id);
                if (promocion != null)
                {
                    promocion.Activa = activa;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado de promoción: {ex.Message}");
            }
        }
    }
}