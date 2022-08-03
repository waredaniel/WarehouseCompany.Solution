using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WarehouseCompany.Models
{
  public class WarehouseCompanyContextFactory : IDesignTimeDbContextFactory<WarehouseCompanyContext>
  {
    WarehouseCompanyContext IDesignTimeDbContextFactory<WarehouseCompanyContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<WarehouseCompanyContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new WarehouseCompanyContext(builder.Options);
    }
  }
}