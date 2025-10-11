using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SorveteriaApp.Domain.Entities;
using SorveteriaApp.Domain.Interfaces;
using SorveteriaApp.Infrastructure.Data;

namespace SorveteriaApp.Infrastructure.Repositories
{
    public class SaborRepository : ISaborRepository
    {
        private readonly ApplicationDbContext _context;

        public SaborRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sabor>> GetAllAsync()
        {
            return await _context.Sabores
                .OrderBy(s => s.Categoria)
                .ThenBy(s => s.Nome)
                .ToListAsync();
        }

        public async Task<Sabor> GetByIdAsync(int id)
        {
            return await _context.Sabores.FindAsync(id);
        }

        public async Task<Sabor> GetByCodigoAsync(string codigo)
        {
            return await _context.Sabores
                .FirstOrDefaultAsync(s => s.CodigoProduto == codigo);
        }

        public async Task<IEnumerable<Sabor>> GetByCategoriaAsync(string categoria)
        {
            return await _context.Sabores
                .Where(s => s.Categoria == categoria)
                .OrderBy(s => s.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sabor>> GetDisponiveisAsync()
        {
            return await _context.Sabores
                .Where(s => s.Disponivel)
                .OrderBy(s => s.Categoria)
                .ThenBy(s => s.Nome)
                .ToListAsync();
        }

        public async Task AddAsync(Sabor sabor)
        {
            await _context.Sabores.AddAsync(sabor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sabor sabor)
        {
            _context.Sabores.Update(sabor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sabor = await GetByIdAsync(id);
            if (sabor != null)
            {
                _context.Sabores.Remove(sabor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CodigoExistsAsync(string codigo)
        {
            return await _context.Sabores.AnyAsync(s => s.CodigoProduto == codigo);
        }
    }
}
