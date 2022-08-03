using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WarehouseCompany.Models;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseCompany.Controllers
{
  public class OrdersController : Controller
  {
    private readonly WarehouseCompanyContext _db;

    public OrdersController(WarehouseCompanyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "View All Orders";
      return View(_db.Orders.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "New Order";
      ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "ProductName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Order order, int ProductId)
    {
      _db.Orders.Add(order);
      _db.SaveChanges();
      if(ProductId != 0)
      {
        _db.ProductOrder.Add(new ProductOrder(){ ProductId = ProductId, OrderId = order.OrderId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisOrder = _db.Orders
        .Include(order => order.JoinEntities2)
        .ThenInclude(join => join.Product)
        .FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    public ActionResult Edit(int id)
    {
      var thisOrder = _db.Orders.FirstOrDefault(order => order.OrderId == id);
      return View(thisOrder);
    }

    [HttpPost]
    public ActionResult Edit (Order order)
    {
      _db.Entry(order).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}