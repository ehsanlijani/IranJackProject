using IranJackProject.Domain.Models.InventoryRecords;
using IranJackProject.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IranJackProject.Infrastructure.Persistence.Context;

public class IranJackDbContext(DbContextOptions<IranJackDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    public DbSet<InventoryRecord> InventoryRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
