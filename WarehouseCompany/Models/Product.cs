using System.Collections.Generic;

namespace WarehouseCompany.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinEntities = new HashSet<ProductSupplier>();
      this.JoinEntities2 = new HashSet<ProductOrder>();
    }

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }

    public virtual ICollection<ProductSupplier> JoinEntities { get; }
    public virtual ICollection<ProductOrder> JoinEntities2 { get; }
  }
}