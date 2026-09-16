using Silox.Data.DTOs.Garson;

namespace Silox.Data.Interfaces;

public interface IGarsonService
{
    Task<List<SumarniTopliObrokRadnikaDTO>> GetReprezentiKarticePagedAsync(
        int pageIndex,
        int pageSize,
        string search,
        DateTime? datumOd = null
    );
}