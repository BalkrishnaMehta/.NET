using Microsoft.AspNetCore.Mvc;

namespace practical3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            DateTime currentTime = DateTime.Now;
            string timeOfDay;

            if (currentTime.Hour >= 0 && currentTime.Hour < 12)
            {
                timeOfDay = "Morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                timeOfDay = "Afternoon";
            }
            else
            {
                timeOfDay = "Evening";
            }
            return View("Index", timeOfDay);
        }
    }
}