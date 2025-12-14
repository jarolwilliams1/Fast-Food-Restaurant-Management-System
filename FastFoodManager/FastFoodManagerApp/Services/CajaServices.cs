using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{
    public class CajaService : ICajaService
    {
        private readonly IProductsRepository _productRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public CajaService(IProductsRepository productRepository, IPedidoRepository pedidoRepository)
        {
            _productRepository = productRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<Producto>> ObtenerProductosDisponiblesAsync()
        {
            try
            {
                return await _productRepository.ObtenerProductosDisponiblesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener productos: {ex.Message}");
            }
        }

        public async Task<int> CompletarVentaAsync(VentaDTO venta)
        {
            try
            {
                // Validaciones
                if (venta.Items == null || !venta.Items.Any())
                    throw new ArgumentException("El carrito está vacío");

                if (!ValidarPago(venta.Total, venta.MontoPagado))
                    throw new ArgumentException("El monto pagado es insuficiente");

                // Crear el pedido
                var pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    ClienteId = venta.ClienteId,
                    EmpleadoId = venta.EmpleadoId,
                    Total = venta.Total,
                    Estado = "Completado"
                };

                var pedidoCreado = await _pedidoRepository.CrearPedidoAsync(pedido);

                // Crear los items del pedido
                var pedidoItems = venta.Items.Select(item => new PedidoItem
                {
                    PedidoId = pedidoCreado.Id,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Subtotal = item.Subtotal,
                    CodigoPedido = $"PED-{pedidoCreado.Id}-{DateTime.Now:yyyyMMddHHmmss}"
                }).ToList();

                await _pedidoRepository.AgregarItemsPedidoAsync(pedidoItems);

                return pedidoCreado.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al completar la venta: {ex.Message}");
            }
        }

        public decimal CalcularTotal(List<CarritoItemDTO> items)
        {
            if (items == null || !items.Any())
                return 0;

            return items.Sum(item => item.Subtotal);
        }

        public decimal CalcularCambio(decimal total, decimal montoPagado)
        {
            if (montoPagado < total)
                return 0;

            return montoPagado - total;
        }

        public bool ValidarPago(decimal total, decimal montoPagado)
        {
            return montoPagado >= total;
        }
    }
}