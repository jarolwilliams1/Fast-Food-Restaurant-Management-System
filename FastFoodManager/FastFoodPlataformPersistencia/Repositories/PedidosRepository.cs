using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> CrearPedidoAsync(Pedido pedido);
        Task<bool> AgregarItemsPedidoAsync(List<PedidoItem> items);
        Task<Pedido> ObtenerPedidoPorIdAsync(int id);
        Task<List<Pedido>> ObtenerPedidosPorFechaAsync(DateTime fecha);
        Task<List<Pedido>> ObtenerTodosPedidosAsync();
        Task<bool> ActualizarEstadoPedidoAsync(int pedidoId, string nuevoEstado);
        Task<bool> ActualizarPedidoAsync(Pedido pedido);
    }

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
                    .Include(p => p.PedidoItems)
                        .ThenInclude(pi => pi.Combo)
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
                        .ThenInclude(pi => pi.Producto)
                    .Include(p => p.PedidoItems)
                        .ThenInclude(pi => pi.Combo)
                    .Include(p => p.Cliente)
                    .Include(p => p.Empleado)
                    .Where(p => p.Fecha.Date == fecha.Date)
                    .OrderByDescending(p => p.Fecha)
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
                        .ThenInclude(pi => pi.Producto)
                    .Include(p => p.PedidoItems)
                        .ThenInclude(pi => pi.Combo)
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

        public async Task<bool> ActualizarEstadoPedidoAsync(int pedidoId, string nuevoEstado)
        {
            try
            {
                var pedido = await _context.Pedidos.FindAsync(pedidoId);
                if (pedido == null)
                    return false;

                pedido.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar estado del pedido: {ex.Message}");
            }
        }

        public async Task<bool> ActualizarPedidoAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar pedido: {ex.Message}");
            }
        }
    }
}
