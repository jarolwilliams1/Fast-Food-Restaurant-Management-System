namespace FastFoodManagerApp.Services.DTOs
{
    public class PromocionDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; } // "Combo" o "Descuento"
        public decimal? DiscountValue { get; set; } // % de descuento
        public decimal? FixedPrice { get; set; } // Precio fijo del combo
        public string? ProductsSummary { get; set; } // Lista de productos incluidos (string)
        public bool Active { get; set; }
        public string? Description { get; set; }
        public string? Tipo { get; set; }
        public bool Activa { get; set; }
    }
}
