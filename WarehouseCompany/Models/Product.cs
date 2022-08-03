using System.Collections.Generic;

namespace WarehouseCompany.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinEntities = new HashSet<ProductSupplier>();
    }

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }

    public virtual ICollection<ProductSupplier> JoinEntities { get; }
  }
}