using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WarehouseCompany.Models
{
  public class Order
  {
    public Order()
    {
      this.JoinEntities2 = new HashSet<ProductOrder>();
    }
    
    public int OrderId { get; set; }
    public string Name { get; set; }
    [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime OrderDate { get; set; }
    public int OrderQuantity { get; set; }
    public int OrderPrice { get; set; }
    private bool _orderStatus = false;
    public bool OrderStatus 
    { 
      get
      {
        return _orderStatus;
      }
      set
      {
        _orderStatus = value;
      }
    }

    public virtual ICollection<ProductOrder> JoinEntities2 { get; }
  }
}