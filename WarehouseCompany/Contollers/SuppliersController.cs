using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WarehouseCompany.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WarehouseCompany.Controllers
{
  public class SuppliersController : Controller
  {
    private readonly WarehouseCompanyContext _db;

    public SuppliersController(WarehouseCompanyContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchString)
    {
      ViewBag.PageTitle = "View All Products";
      if (!String.IsNullOrEmpty(searchString))
      {
        List<Supplier> model = _db.Suppliers
          .Where(supplier => supplier.SupplierName.Contains(searchString))
          .OrderBy(supplier => supplier.SupplierName)
          .ToList();
        return View(model);
      }
      else
      {
        List<Supplier> model = _db.Suppliers
          .OrderBy(supplier => supplier.SupplierName)
          .ToList();
        return View(model);
      }
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Supplier supplier)
    {
      _db.Suppliers.Add(supplier);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSupplier = _db.Suppliers
        .Include(supplier => supplier.JoinEntities)
        .ThenInclude(join => join.Product)
        .FirstOrDefault(supplier => supplier.SupplierId == id);
      return View(thisSupplier);
    }

    public ActionResult Delete(int id)
    {
      var thisSupplier = _db.Suppliers.FirstOrDefault(supplier => supplier.SupplierId == id);
      return View(thisSupplier);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSupplier = _db.Suppliers.FirstOrDefault(supplier => supplier.SupplierId ==id);
      _db.Suppliers.Remove(thisSupplier);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit (int id)
    {
      var thisSupplier = _db.Suppliers.FirstOrDefault(supplier => supplier.SupplierId == id);
      return View(thisSupplier);
    }

    [HttpPost]
    public ActionResult Edit(Supplier supplier)
    {
      _db.Entry(supplier).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}