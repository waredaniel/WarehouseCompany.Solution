using Microsoft.EntityFrameworkCore;

namespace WarehouseCompany.Models
{
  public class WarehouseCompanyContext : DbContext
  {
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSupplier> ProductSupplier { get; set; }

    public WarehouseCompanyContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}