using Microsoft.EntityFrameworkCore;
using Silox.Data.Models;

namespace Silox.Service.DBContexts
{
    public class EArhivaDbContext(DbContextOptions<EArhivaDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<EArhiva> earhiva { get; set; }
    }
}