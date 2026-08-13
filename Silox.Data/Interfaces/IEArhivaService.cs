using Silox.Data.DTOs;

namespace Silox.Data.Interfaces;

public interface IEArhivaService
{
    Task<List<EArhivaDTO>> GetPagedAsync(int pageIndex, int pageSize);
    // Task<EArhiva?> GetByIdAsync(int id);
    // Task<EArhiva> CreateAsync(EArhiva entity);
    // Task<bool> UpdateAsync(EArhiva entity);
    // Task<bool> DeleteAsync(int id);
}