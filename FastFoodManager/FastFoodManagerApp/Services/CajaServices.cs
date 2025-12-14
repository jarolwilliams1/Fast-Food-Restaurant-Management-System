using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Repositories;

namespace FastFoodManagerApp.Services
{


   



    public class CajaService : ICajaService
    {
        private readonly IProductsRepository _productRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public CajaService(IProductsRepository productRepository, IPedidoRepository repo)
        {
            _productRepository = productRepository;
            _pedidoRepository = repo;
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

                // Crear el pedido en la base de datos
                var pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    ClienteId = venta.ClienteId,
                    EmpleadoId = venta.EmpleadoId,
                    Total = venta.Total,
                    Estado = "Completado" // Estado cuando se completa desde la caja
                };

                var pedidoCreado = await _pedidoRepository.CrearPedidoAsync(pedido);

                // Generar código de pedido único
                string codigoPedido = $"PED-{pedidoCreado.Id}-{DateTime.Now:yyyyMMddHHmmss}";

                // Crear los items del pedido en la base de datos
                var pedidoItems = venta.Items.Select(item => new PedidoItem
                {
                    CodigoPedido = codigoPedido,
                    PedidoId = pedidoCreado.Id,
                    ProductoId = item.ProductoId,
                    ComboId = null, // Por ahora solo manejamos productos, no combos
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Precio,
                    Subtotal = item.Subtotal
                }).ToList();

                // Guardar los items en la base de datos
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