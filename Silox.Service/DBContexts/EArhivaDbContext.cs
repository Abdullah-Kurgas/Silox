using Microsoft.EntityFrameworkCore;

namespace Silox.Service.DBContexts
{
    public class EArhivaDbContext(DbContextOptions<EArhivaDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}