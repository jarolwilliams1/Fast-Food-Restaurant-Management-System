using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;

namespace FastFoodManagerApp.Services
{
    public interface ICajaService
    {
        Task<List<Producto>> ObtenerProductosDisponiblesAsync();
        Task<int> CompletarVentaAsync(VentaDTO venta);
        decimal CalcularTotal(List<CarritoItemDTO> items);
        decimal CalcularCambio(decimal total, decimal montoPagado);
        bool ValidarPago(decimal total, decimal montoPagado);
    }
}

