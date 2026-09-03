using Silox.Data.DTOs;
using Silox.Data.Models;

namespace Silox.Data.Interfaces;

public interface IEArhivaService
{
    Task<List<EArhivaDTO>> GetPagedAsync(int pageIndex, int pageSize);
    Task<EArhiva?> GetItemDetailsAsync(int id);
}