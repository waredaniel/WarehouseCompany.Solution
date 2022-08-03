using System.Collections.Generic;

namespace WarehouseCompany.Models
{
  public class Product
  {
    public Prodcut()
    {
      this.JoinEntities = new HashSet<ProductDescription>();
    }

    public int ProductId { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }

    public virtual ICollection<ProductSupplier> JoinEntities { get; }
  }
}