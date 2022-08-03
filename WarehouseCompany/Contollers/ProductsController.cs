using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WarehouseCompany.Models;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseCompany.Controllers
{
  public class ProductsController : Controller
  {
    private readonly WarehouseCompanyContext _db;

    public ProductsController(WarehouseCompanyContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Products.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SupplierId = new SelectList(_db.Suppliers, "SupplierId", "SupplierName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Product product, int SupplierId)
    {
      _db.Products.Add(product);
      _db.SaveChanges();
      if (SupplierId != 0)
      {
        _db.ProductSupplier.Add(new ProductSupplier() { SupplierId = SupplierId, ProductId = product.ProductId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisProduct = _db.Products
        .Include(product => product.JoinEntities)
        .ThenInclude(join => join.Supplier)
        .FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    public ActionResult Delete (int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      return View(thisProduct);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      _db.Products.Remove(thisProduct);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisProduct = _db.Products.FirstOrDefault(product => product.ProductId == id);
      ViewBag.ProductId = new SelectList(_db.Suppliers, "SupplierId", "SupplierName");
      return View(thisProduct);
    }

    [HttpPost] 
    public ActionResult Edit (Product product, int SupplierId)
    {
      if (SupplierId != 0)
      {
        _db.ProductSupplier.Add(new ProductSupplier() { SupplierId = SupplierId, ProductId = product.ProductId });
      }
      _db.Entry(product).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}