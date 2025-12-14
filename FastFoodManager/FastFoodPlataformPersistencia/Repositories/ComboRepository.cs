using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFoodManagerPlataformDomain.Entites;
using FastFoodPlataformPersistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace FastFoodPlataformPersistencia.Repositories
{
    // Interface requerida
    public interface IComboRepository
    {
        Task<List<Combo>> ObtenerTodosCombosAsync();
        Task AgregarComboAsync(Combo combo);
        Task ActualizarComboAsync(Combo combo);
        Task<Combo> ObtenerComboPorIdAsync(int id);
    }

    public class ComboRepository : IComboRepository
    {
        private readonly FastFoodManagerDBContext _context;

        public ComboRepository(FastFoodManagerDBContext context)
        {
            _context = context;
        }

        public async Task<List<Combo>> ObtenerTodosCombosAsync()
        {
            // Incluye los productos que componen el combo
            return await _context.Combos
                .Include(c => c.ComboProductos)
                .ThenInclude(cp => cp.Producto)
                .ToListAsync();
        }

        public async Task AgregarComboAsync(Combo combo)
        {
            _context.Combos.Add(combo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarComboAsync(Combo combo)
        {
            _context.Combos.Update(combo);
            await _context.SaveChangesAsync();
        }

        public async Task<Combo> ObtenerComboPorIdAsync(int id)
        {
            return await _context.Combos
                .Include(c => c.ComboProductos)
                .ThenInclude(cp => cp.Producto)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
