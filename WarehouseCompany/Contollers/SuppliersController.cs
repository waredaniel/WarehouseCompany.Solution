using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WarehouseCompany.Models;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseCompany.Controllers
{
  public class SuppliersController : Controller
  {
    private readonly WarehouseCompanyContext _db;

    public SuppliersController(WarehouseCompanyContext db)
    {
      _db = db;
    }

    public ActionResult Index ()
    {
      ViewBag.PageTitle = "All suppliers";
      List<Supplier> model = _db.Suppliers.ToList();
      return View(model);
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

  }
}