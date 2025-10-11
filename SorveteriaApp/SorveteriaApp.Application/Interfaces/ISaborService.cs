using System.Collections.Generic;
using System.Threading.Tasks;
using SorveteriaApp.Application.DTOs;

namespace SorveteriaApp.Application.Interfaces
{
    public interface ISaborService
    {
        Task<IEnumerable<SaborDto>> GetAllSaboresAsync();
        Task<SaborDto> GetSaborByIdAsync(int id);
        Task<IEnumerable<SaborDto>> GetSaboresByCategoriaAsync(string categoria);
        Task<IEnumerable<SaborDto>> GetSaboresDisponiveisAsync();
        Task<SaborDto> CreateSaborAsync(SaborCreateDto saborDto);
        Task UpdateSaborAsync(SaborUpdateDto saborDto);
        Task DeleteSaborAsync(int id);
        Task<bool> CodigoExistsAsync(string codigo, int? saborId = null);
    }
}
