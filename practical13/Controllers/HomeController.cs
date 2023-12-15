using Microsoft.AspNetCore.Mvc;
using practical13.Models;

namespace practical13.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["Message3"] = "Hello From TempData";
            return RedirectToAction("Index2");
        }
        public IActionResult Index2() {
            ViewData["Message1"] = "Hello From ViewData";
            ViewData["Address1"] = new Address()
            {
                Name = "Steve",
                Street = "123 Main st",
                City = "Hudson",
                State = "OH",
                PostalCode = "44236"
            };

            ViewBag.Message2 = "Hello From ViewBag";
            return View();
        }
    }
}
