using Microsoft.EntityFrameworkCore;
using Silox.Data.DTOs;
using Silox.Data.Interfaces;
using Silox.Service.DBContexts;

namespace Silox.Service.Services.EArhivaServices;

public class EArhivaService(EArhivaDbContext context) : BaseService<EArhivaDbContext>(context), IEArhivaService
{
    public async Task<List<EArhivaDTO>> GetPagedAsync(int pageIndex, int pageSize)
    {
        return await _context.earhiva
            .AsNoTracking()
            .OrderByDescending(e => e.Vrijeme)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new EArhivaDTO
            {
                Id = e.Id,
                ImeVozaca = e.ImeVozaca,
                Izvor = e.Izvor,
                SifraPp = e.SifraPp,
                NazivPp = e.NazivPp,
                BrojDokumenta = e.BrojDokumenta,
                VrstaDokumenta = e.VrstaDokumenta,
                DatumDokumenta = e.DatumDokumenta,
                Iznos = e.Iznos,
                Vrijeme = e.Vrijeme,
                Verzija = e.Verzija,
                Isporuka = e.Isporuka
            })
            .Take(100)
            .ToListAsync();
    }
}