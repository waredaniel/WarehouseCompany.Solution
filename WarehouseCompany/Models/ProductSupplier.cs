namespace WarehouseCompany.Models
{
  public class ProductSupplier
  {
    public int ProductSupplierId { get; set;}
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
  
    public virtual Supplier Supplier { get; set; }
    public virtual Product Product { get; set; }
  }
}