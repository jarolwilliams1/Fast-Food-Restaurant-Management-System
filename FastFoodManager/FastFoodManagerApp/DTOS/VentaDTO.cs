using System.Collections.Generic;

namespace FastFoodManagerApp.Services
{
    public class VentaDTO
    {
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public List<CarritoItemDTO> Items { get; set; }
        public decimal Total { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal Cambio { get; set; }
    }
}
