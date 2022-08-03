namespace ProductSupplier.Models
{
  public class ProductSupplier
  {
    public int ProductSupplierId { get; set;}
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
    public string ProductSupplierDate { get; set; }
    public string ProductSupplierQuantity { get; set; }
    public int ProductSupplierPrice { get; set; }
    public string ProductSupplierStatus { get; set; }

    public virtual Supplier Supplier { get; set; }
    public virtual Product Product { get; set; }
  }
}