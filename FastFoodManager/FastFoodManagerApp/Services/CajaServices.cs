using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{
    public class CarritoItemDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
    }

    public class VentaDTO
    {
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public List<CarritoItemDTO> Items { get; set; }
        public decimal Total { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Cambio { get; set; }
    }

  

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

        public async Task<string> CompletarVentaAsync(VentaDTO venta)
        {
            try
            {
                // Validar que hay items
                if (venta.Items == null || venta.Items.Count == 0)
                {
                    throw new Exception("No hay productos en el carrito");
                }

                // Validar pago suficiente
                if (!ValidarPago(venta.Total, venta.MontoPagado))
                {
                    throw new Exception("El monto pagado es insuficiente");
                }

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

                // Generar código de pedido
                string codigoPedido = $"PED-{pedidoCreado.Id}-{DateTime.Now:yyyyMMddHHmmss}";

                // Crear los items del pedido
                var pedidoItems = venta.Items.Select(item => new PedidoItem
                {
                    CodigoPedido = codigoPedido,
                    PedidoId = pedidoCreado.Id,
                    ProductoId = item.ProductoId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Precio,
                    Subtotal = item.Subtotal
                }).ToList();

                await _pedidoRepository.AgregarItemsPedidoAsync(pedidoItems);

                return codigoPedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al completar la venta: {ex.Message}");
            }
        }

        public decimal CalcularTotal(List<CarritoItemDTO> items)
        {
            if (items == null || items.Count == 0)
                return 0;

            return items.Sum(item => item.Subtotal);
        }

        public decimal CalcularCambio(decimal total, decimal montoPagado)
        {
            return montoPagado - total;
        }

        public bool ValidarPago(decimal total, decimal montoPagado)
        {
            return montoPagado >= total && total > 0;
        }
    }
}
