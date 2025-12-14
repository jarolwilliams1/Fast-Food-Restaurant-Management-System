using FastFoodManagerApp.Services.DTOs;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodManagerPlataformDomain.Interfaces;
using FastFoodPlataformPersistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{

    public class PromocionService// : IPromocionService
    {
        private readonly IPromocionRepository _promocionRepo;
        private readonly IComboRepository _comboRepo;
        private readonly IProductsRepository _productRepo; // Para verificar productos en la BD

        // Se inyectan ambos repositorios
        public PromocionService(IPromocionRepository promocionRepo, IComboRepository comboRepo, IProductsRepository productRepo)
        {
            _promocionRepo = promocionRepo;
            _comboRepo = comboRepo;
            _productRepo = productRepo;
        }

        public async Task<bool> CrearPromocionAsync(string nombre, string tipo, decimal valor, string descripcion, List<int> productosIds, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var dto = new PromocionDTO
            {
                Name = nombre,
                Type = tipo.Equals("COMBO", StringComparison.OrdinalIgnoreCase) ? "Combo" : "Descuento",
                FixedPrice = tipo.Equals("COMBO", StringComparison.OrdinalIgnoreCase) ? (decimal?)valor : null,
                DiscountValue = tipo.Equals("DESCUENTO", StringComparison.OrdinalIgnoreCase) ? (decimal?)valor : null,
                Description = descripcion,
                ProductsSummary = productosIds != null ? string.Join(", ", productosIds) : string.Empty,
                Active = true
            };

            // Reutiliza el método existente (firma anterior en la clase)
            return await CrearPromocionAsync(string.Empty, dto);
        }
        public async Task<List<PromocionDTO>> ObtenerTodasOfertasAsync()
        {
            var descuentos = await _promocionRepo.ObtenerTodasPromocionesAsync();
            var combos = await _comboRepo.ObtenerTodosCombosAsync();

            var listaOfertas = new List<PromocionDTO>();

            // Mapeo de Descuentos
            listaOfertas.AddRange(descuentos.Select(p => new PromocionDTO
            {
                Id = p.Id,
                Name = p.Nombre,
                Type = "Descuento",
                DiscountValue = p.Valor,
                Description = p.Tipo, // Usamos el campo Tipo para la descripción del descuento
                ProductsSummary = "Varios productos", // Esto debe ser mejorado si la entidad PromocionProducto se usa
                Active = p.Activa
            }));

            // Mapeo de Combos
            listaOfertas.AddRange(combos.Select(c => new PromocionDTO
            {
                Id = c.Id,
                Name = c.Nombre,
                Type = "Combo",
                FixedPrice = c.PrecioCombo,
                Description = c.Nombre, // Aquí puedes usar un campo de descripción real si existiera
                ProductsSummary = string.Join(", ", c.ComboProductos.Select(cp => $"{cp.Cantidad}x {cp.Producto.Nombre}")),
                Active = c.Activo
            }));

            return listaOfertas.OrderBy(o => o.Type).ToList();
        }

        public async Task<bool> CrearPromocionAsync(string text, PromocionDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("El nombre es requerido.");

            if (dto.Type == "Combo")
            {
                if (dto.FixedPrice <= 0)
                    throw new ArgumentException("El precio del combo debe ser mayor a cero.");

                var newCombo = new Combo
                {
                    Nombre = dto.Name,
                    PrecioCombo = dto.FixedPrice.Value,
                    Activo = true,
                    // NOTA: La lógica para parsear 'ProductsSummary' y llenar 'ComboProductos' 
                    // es compleja y se omitió por brevedad, pero aquí iría.
                    // Ejemplo: newCombo.ComboProductos.Add(new ComboProducto { ProductoId = X, Cantidad = Y });
                };
                await _comboRepo.AgregarComboAsync(newCombo);
            }
            else if (dto.Type == "Descuento")
            {
                if (dto.DiscountValue <= 0 || dto.DiscountValue > 100)
                    throw new ArgumentException("El descuento debe ser entre 1% y 100%.");

                var newPromocion = new Promocione
                {
                    Nombre = dto.Name,
                    Tipo = dto.Description, // Usando Description para el campo 'Tipo' de la BD
                    Valor = dto.DiscountValue.Value,
                    Activa = true,
                    FechaInicio = DateTime.Now
                };
                await _promocionRepo.AgregarPromocionAsync(newPromocion);
            }
            else
            {
                throw new ArgumentException("Tipo de promoción no válido.");
            }
            return true;
        }

        public async Task<bool> CambiarEstadoAsync(int id, string type, bool activo)
        {
            if (type == "Combo")
            {
                var combo = await _comboRepo.ObtenerComboPorIdAsync(id);
                if (combo != null)
                {
                    combo.Activo = activo;
                    await _comboRepo.ActualizarComboAsync(combo);
                    return true;
                }
            }
            else if (type == "Descuento")
            {
                var promocion = await _promocionRepo.ObtenerPromocionPorIdAsync(id);
                if (promocion != null)
                {
                    promocion.Activa = activo;
                    await _promocionRepo.ActualizarPromocionAsync(promocion);
                    return true;
                }
            }
            return false;
        }

       
    }
}
