using FastFoodManagerApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastFoodManagerApp.Services
{
    public interface IPromocionService
    {
        Task<List<PromocionDTO>> ObtenerTodasPromocionesAsync();
        Task<List<PromocionDTO>> ObtenerPromocionesActivasAsync();
        Task<List<PromocionDTO>> ObtenerPromocionesPorTipoAsync(string tipo);
        Task<bool> CrearPromocionAsync(
            string nombre,
            string tipo,
            decimal valor,
            string descripcion,
            List<int> productosIds,
            DateTime? fechaInicio = null,
            DateTime? fechaFin = null);
        Task<bool> ActualizarPromocionAsync(
            int id,
            string nombre,
            decimal valor,
            string descripcion,
            bool activa,
            List<int> productosIds);
        Task<bool> CambiarEstadoPromocionAsync(int id);
        Task<bool> EliminarPromocionAsync(int id);
        Task<bool> ValidarPromocionVigente(int promocionId);
    }
}
