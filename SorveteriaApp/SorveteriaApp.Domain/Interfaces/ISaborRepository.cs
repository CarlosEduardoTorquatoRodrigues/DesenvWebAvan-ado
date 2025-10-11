using System.Collections.Generic;
using System.Threading.Tasks;
using SorveteriaApp.Domain.Entities;

namespace SorveteriaApp.Domain.Interfaces
{
    public interface ISaborRepository
    {
        Task<IEnumerable<Sabor>> GetAllAsync();
        Task<Sabor> GetByIdAsync(int id);
        Task<Sabor> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Sabor>> GetByCategoriaAsync(string categoria);
        Task<IEnumerable<Sabor>> GetDisponiveisAsync();
        Task AddAsync(Sabor sabor);
        Task UpdateAsync(Sabor sabor);
        Task DeleteAsync(int id);
        Task<bool> CodigoExistsAsync(string codigo);
    }
}
