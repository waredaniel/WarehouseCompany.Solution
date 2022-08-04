using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WarehouseCompany.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WarehouseCompany.Controllers
{
  public class OrdersController : Controller
  {
    private readonly WarehouseCompanyContext _db;

    public OrdersController(WarehouseCompanyContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchString)
    {
      ViewBag.PageTitle = "View All Orders";
      if (!String.IsNullOrEmpty(searchString))
      {
        List<Order> model = _db.Orders
          .Where(order => order.Name.Contains(searchString))
          .OrderBy(order => order.Name)
          .ToList();
        return View(model);
      }
      else
      {
        List<Order> model = _db.Orders
          .OrderBy(order => order.Name)
          .ToList();
        return View(model);
      }
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
      ViewBag.ProductId = new SelectList(_db.Products, "ProductId", "ProductName");
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