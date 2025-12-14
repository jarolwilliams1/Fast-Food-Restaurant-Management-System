using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Repositories;

namespace FastFoodManagerApp.Services
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public string CodigoPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string ClienteNombre { get; set; }
        public string EmpleadoNombre { get; set; }
        public List<string> Items { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string Hora => Fecha.ToString("hh:mm tt");
        public string ItemsTexto => Items != null && Items.Count > 0
            ? string.Join(", ", Items)
            : "Sin items";
    }

    public class CrearPedidoDTO
    {
        public string NumeroOrden { get; set; }
        public List<string> ItemsTexto { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
    }

    public interface IPedidoService
    {
        Task<List<PedidoDTO>> ObtenerTodosPedidosAsync();
        Task<List<PedidoDTO>> ObtenerPedidosPorEstadoAsync(string estado);
        Task<List<PedidoDTO>> ObtenerPedidosDelDiaAsync();
        Task<PedidoDTO> ObtenerPedidoPorIdAsync(int id);
        Task<bool> CambiarEstadoPedidoAsync(int pedidoId, string nuevoEstado);
        Task<string> ObtenerSiguienteEstadoAsync(string estadoActual);
        Task<string> CrearNuevoPedidoAsync(CrearPedidoDTO nuevoPedido);
    }

    public class PedidoService : IPedidoService
    {
        private readonly FastFoodPlataformPersistencia.Repositories.IPedidoRepository _pedidoRepository;

        public PedidoService(FastFoodPlataformPersistencia.Repositories.IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<List<PedidoDTO>> ObtenerTodosPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoRepository.ObtenerTodosPedidosAsync();
                return ConvertirAPedidoDTOs(pedidos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedidos: {ex.Message}");
            }
        }

        public async Task<List<PedidoDTO>> ObtenerPedidosPorEstadoAsync(string estado)
        {
            try
            {
                var pedidos = await _pedidoRepository.ObtenerTodosPedidosAsync();
                var pedidosFiltrados = pedidos
                    .Where(p => p.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                return ConvertirAPedidoDTOs(pedidosFiltrados);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedidos por estado: {ex.Message}");
            }
        }

        public async Task<List<PedidoDTO>> ObtenerPedidosDelDiaAsync()
        {
            try
            {
                var hoy = DateTime.Today;
                var pedidos = await _pedidoRepository.ObtenerPedidosPorFechaAsync(hoy);
                return ConvertirAPedidoDTOs(pedidos);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedidos del día: {ex.Message}");
            }
        }

        public async Task<PedidoDTO> ObtenerPedidoPorIdAsync(int id)
        {
            try
            {
                var pedido = await _pedidoRepository.ObtenerPedidoPorIdAsync(id);
                if (pedido == null)
                    throw new Exception($"No se encontró el pedido con ID {id}");

                return ConvertirAPedidoDTO(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener pedido: {ex.Message}");
            }
        }

        public async Task<string> CrearNuevoPedidoAsync(CrearPedidoDTO nuevoPedido)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(nuevoPedido.NumeroOrden))
                    throw new ArgumentException("El número de orden no puede estar vacío");

                if (nuevoPedido.Total <= 0)
                    throw new ArgumentException("El total debe ser mayor a cero");

                if (nuevoPedido.ItemsTexto == null || nuevoPedido.ItemsTexto.Count == 0)
                    throw new ArgumentException("Debe agregar al menos un item al pedido");

                // Crear el pedido
                var pedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    ClienteId = nuevoPedido.ClienteId,
                    EmpleadoId = nuevoPedido.EmpleadoId,
                    Total = nuevoPedido.Total,
                    Estado = "Pendiente" // Los pedidos nuevos siempre empiezan como Pendiente
                };

                var pedidoCreado = await _pedidoRepository.CrearPedidoAsync(pedido);

                // Generar código de pedido
                string codigoPedido = nuevoPedido.NumeroOrden.StartsWith("#")
                    ? nuevoPedido.NumeroOrden
                    : $"#{nuevoPedido.NumeroOrden}";

                // Crear items del pedido (como texto genérico por ahora)
                // Nota: Estos son items de texto, no productos reales de la BD
                var pedidoItems = nuevoPedido.ItemsTexto.Select((item, index) => new PedidoItem
                {
                    CodigoPedido = codigoPedido,
                    PedidoId = pedidoCreado.Id,
                    ProductoId = null, // No asociamos con productos específicos
                    ComboId = null,
                    Cantidad = 1,
                    PrecioUnitario = nuevoPedido.Total / nuevoPedido.ItemsTexto.Count, // Distribuir el precio
                    Subtotal = nuevoPedido.Total / nuevoPedido.ItemsTexto.Count
                }).ToList();

                await _pedidoRepository.AgregarItemsPedidoAsync(pedidoItems);

                return codigoPedido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear pedido: {ex.Message}");
            }
        }

        public async Task<bool> CambiarEstadoPedidoAsync(int pedidoId, string nuevoEstado)
        {
            try
            {
                var pedido = await _pedidoRepository.ObtenerPedidoPorIdAsync(pedidoId);
                if (pedido == null)
                    throw new Exception($"No se encontró el pedido con ID {pedidoId}");

                if (!EsTransicionValida(pedido.Estado, nuevoEstado))
                    throw new Exception($"No se puede cambiar de {pedido.Estado} a {nuevoEstado}");

                bool resultado = await _pedidoRepository.ActualizarEstadoPedidoAsync(pedidoId, nuevoEstado);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar estado del pedido: {ex.Message}");
            }
        }

        public Task<string> ObtenerSiguienteEstadoAsync(string estadoActual)
        {
            string siguienteEstado = estadoActual switch
            {
                "Pendiente" => "Preparando",
                "Preparando" => "Listo",
                "Listo" => "Entregado",
                "En Preparación" => "Listo",
                "Completado" => "Completado",
                "Entregado" => "Entregado",
                _ => "Pendiente"
            };

            return Task.FromResult(siguienteEstado);
        }

        private bool EsTransicionValida(string estadoActual, string nuevoEstado)
        {
            var transicionesValidas = new Dictionary<string, List<string>>
            {
                { "Pendiente", new List<string> { "Preparando", "En Preparación", "Cancelado" } },
                { "Preparando", new List<string> { "Listo", "Cancelado" } },
                { "En Preparación", new List<string> { "Listo", "Cancelado" } },
                { "Listo", new List<string> { "Entregado", "Completado" } },
                { "Completado", new List<string> { } },
                { "Entregado", new List<string> { } },
                { "Cancelado", new List<string> { } }
            };

            if (!transicionesValidas.ContainsKey(estadoActual))
                return false;

            return transicionesValidas[estadoActual].Contains(nuevoEstado);
        }

        private List<PedidoDTO> ConvertirAPedidoDTOs(List<Pedido> pedidos)
        {
            return pedidos.Select(p => ConvertirAPedidoDTO(p)).ToList();
        }

        private PedidoDTO ConvertirAPedidoDTO(Pedido pedido)
        {
            var itemsNombres = new List<string>();

            if (pedido.PedidoItems != null && pedido.PedidoItems.Any())
            {
                foreach (var item in pedido.PedidoItems)
                {
                    string nombreItem = "Item desconocido";

                    if (item.ProductoId.HasValue && item.Producto != null)
                    {
                        nombreItem = $"{item.Producto.Nombre} x{item.Cantidad}";
                    }
                    else if (item.ComboId.HasValue && item.Combo != null)
                    {
                        nombreItem = $"{item.Combo.Nombre} x{item.Cantidad}";
                    }

                    itemsNombres.Add(nombreItem);
                }
            }

            string codigoPedido = $"#{pedido.Id:D3}";

            if (pedido.PedidoItems?.Any() == true)
            {
                var primerItem = pedido.PedidoItems.First();
                if (!string.IsNullOrEmpty(primerItem.CodigoPedido))
                {
                    codigoPedido = primerItem.CodigoPedido.Split('-').FirstOrDefault() ?? codigoPedido;
                }
            }

            return new PedidoDTO
            {
                Id = pedido.Id,
                CodigoPedido = codigoPedido,
                Fecha = pedido.Fecha,
                ClienteNombre = pedido.Cliente?.Nombre + " " + pedido.Cliente?.Apellido ?? "Cliente genérico",
                EmpleadoNombre = pedido.Empleado?.Nombre + " " + pedido.Empleado?.Apellido ?? "Empleado",
                Items = itemsNombres,
                Total = pedido.Total,
                Estado = pedido.Estado
            };
        }
    }
}
