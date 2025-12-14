using FastFoodManagerPlataformDomain.Entites;

public interface IPedidoRepository
{
    Task<Pedido> CrearPedidoAsync(Pedido pedido);
    Task<bool> AgregarItemsPedidoAsync(List<PedidoItem> items);
    Task<Pedido> ObtenerPedidoPorIdAsync(int id);
    Task<List<Pedido>> ObtenerPedidosPorFechaAsync(DateTime fecha);
    Task<List<Pedido>> ObtenerTodosPedidosAsync();
}
