using Microsoft.EntityFrameworkCore;
using Silox.Data.Models;
using Silox.Data.Models.Garson;

namespace Silox.Service.DBContexts;

public class GarsonDbContext(DbContextOptions<GarsonDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public DbSet<Reprezent>? C_REPREZENTI { get; set; }
    public DbSet<ReprezentR>? R_REPREZENTI { get; set; }
    public DbSet<ReprezentiKarticeR>? R_REPREZENTI_KARTICE { get; set; }
    public DbSet<Objekat>? C_OBJEKTI { get; set; }
}