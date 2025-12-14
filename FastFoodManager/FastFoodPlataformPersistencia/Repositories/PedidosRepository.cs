using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
  

    public class PedidoRepository : IPedidoRepository
    {
        private readonly FastFoodManagerDBContext _context;

        public PedidoRepository(FastFoodManagerDBContext context)
        {
            _context = context;
        }

        public async Task<Pedido> CrearPedidoAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el pedido: {ex.Message}");
            }
        }

        public async Task<bool> AgregarItemsPedidoAsync(List<PedidoItem> items)
        {
            try
            {
                _context.PedidoItems.AddRange(items);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar items al pedido: {ex.Message}");
            }
        }

        public async Task<Pedido> ObtenerPedidoPorIdAsync(int id)
        {
            try
            {
                return await _context.Pedidos
                    .Include(p => p.PedidoItems)
                    .ThenInclude(pi => pi.Producto)
                    .Include(p => p.Cliente)
                    .Include(p => p.Empleado)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el pedido: {ex.Message}");
            }
        }

        public async Task<List<Pedido>> ObtenerPedidosPorFechaAsync(DateTime fecha)
        {
            try
            {
                return await _context.Pedidos
                    .Include(p => p.PedidoItems)
                    .Where(p => p.Fecha.Date == fecha.Date)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedidos por fecha: {ex.Message}");
            }
        }

        public async Task<List<Pedido>> ObtenerTodosPedidosAsync()
        {
            try
            {
                return await _context.Pedidos
                    .Include(p => p.PedidoItems)
                    .Include(p => p.Cliente)
                    .Include(p => p.Empleado)
                    .OrderByDescending(p => p.Fecha)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los pedidos: {ex.Message}");
            }
        }
    }
}
