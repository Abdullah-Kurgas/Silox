using Silox.Data.Interfaces;
using Silox.Service.DBContexts;

namespace Silox.Service.Services;

public class GarsonService(GarsonDbContext context) : BaseService<GarsonDbContext>(context), IGarsonService
{
}