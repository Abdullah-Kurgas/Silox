namespace Silox.Service.Services;

using Microsoft.EntityFrameworkCore;

public abstract class BaseService<TContext>(TContext context)
    where TContext : DbContext
{
    protected readonly TContext _context = context;
}