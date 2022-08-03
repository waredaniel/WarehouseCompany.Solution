using System.Collections.Generic;

namespace WarehouseCompany.Models
{
  public class Supplier
  {
    public Supplier()
    {
      this.JoinEntities = new HashSet<ProductSupplier>();
    }

    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string SupplierAddress { get; set; }
    public string SupplierCountry { get; set; }

    public virtual ICollection<ProductSupplier> JoinEntities { get; set; }
  }
}