using Microsoft.AspNetCore.Mvc;

namespace WarehouseCompany.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.PageTitle = "Home";
      return View();
    }
  }
}