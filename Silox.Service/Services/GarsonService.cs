using Microsoft.EntityFrameworkCore;
using Silox.Data.DTOs.Garson;
using Silox.Data.Interfaces;
using Silox.Data.Models.Garson;
using Silox.Service.DBContexts;

namespace Silox.Service.Services;

public class GarsonService(GarsonDbContext context) : BaseService<GarsonDbContext>(context), IGarsonService
{
    public Task<List<Reprezent>> GetReprezentiAsync(
        int pageIndex,
        int pageSize)
    {
        return _context.C_REPREZENTI
            .AsNoTracking()
            .OrderBy(el => el.Ime)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<List<SumarniTopliObrokRadnikaDTO>> GetReprezentiKarticePagedAsync(
        int pageIndex,
        int pageSize,
        string searchString,
        DateTime? datumOd = null)
    {
        var query = _context.R_REPREZENTI_KARTICE
            .AsNoTracking()
            .Where(el => el.Reprezent.Aktivan == 1);


        if (!string.IsNullOrWhiteSpace(searchString))
        {
            var search = searchString.Trim().ToLower();

            query = query.Where(x =>
                EF.Functions.Like(x.Reprezent.Ime.ToLower(), $"%{search}%")
            );
        }

        if (datumOd.HasValue)
        {
            query = query.Where(el => el.Datum >= datumOd.Value.Date);
        }

        return query
            .GroupBy(el => new
            {
                el.IdReprezenta,
                el.Reprezent.Ime
            })
            .Select(g => new SumarniTopliObrokRadnikaDTO()
            {
                IdReprezenta = g.Key.IdReprezenta,
                NazivReprezenta = g.Key.Ime,
                UkupanBrojRacuna = g.Count(),
                UkupanIznos = g.Sum(el => el.Iznos ?? 0)
            })
            .OrderBy(el => el.NazivReprezenta)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}