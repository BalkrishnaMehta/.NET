using Microsoft.AspNetCore.Mvc;
using practical14.Models;

namespace practical14.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (!user.Email.EndsWith("@gmail.com"))
            {
                ModelState.AddModelError("Email", "Only emails from 'gmail.com' domain are allowed.");
                return View(user);
            }

            if (user.Name?.Length < 2 || user.Name?.Length > 50)
            {
                ModelState.AddModelError("Name", "Name length should be between 2 and 50 characters.");
                return View(user);
            }

            return RedirectToAction("RegistrationSuccess");
        }

        public IActionResult RegistrationSuccess()
        {
            return View();
        }

    }
}
