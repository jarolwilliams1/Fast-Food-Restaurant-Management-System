using System.Collections.Generic;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;

namespace FastFoodPlataformPersistencia.Repositories
{
    public interface IPromocionRepository
    {
        Task<List<Promocione>> ObtenerTodasPromocionesAsync();
        Task<List<Promocione>> ObtenerPromocionesActivasAsync();
        Task<List<Promocione>> ObtenerPromocionesPorTipoAsync(string tipo);
        Task<Promocione> ObtenerPromocionPorIdAsync(int id);
        Task AgregarPromocionAsync(Promocione promocion);
        Task ActualizarPromocionAsync(Promocione promocion);
        Task EliminarPromocionAsync(int id);
        Task CambiarEstadoPromocionAsync(int id, bool activa);
    }
}
