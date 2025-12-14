using FastFoodManagerApp.Services;
using FastFoodManagerPlataformDomain.Entites;

public interface ICajaService
{
    Task<List<Producto>> ObtenerProductosDisponiblesAsync();
    Task<string> CompletarVentaAsync(VentaDTO venta);
    decimal CalcularTotal(List<CarritoItemDTO> items);
    decimal CalcularCambio(decimal total, decimal montoPagado);
    bool ValidarPago(decimal total, decimal montoPagado);
}
