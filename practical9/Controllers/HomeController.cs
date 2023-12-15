using Microsoft.AspNetCore.Mvc;

namespace practical9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var username = Request.Cookies["Username"];
            if (username != null)
            {
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("SignUpTime", Request.Cookies["SignUpTime"]!);
                return RedirectToAction("Dashboard", new { user = username });
            }
            else {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(string username, string signUpTime)
        {
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetString("SignUpTime", signUpTime);
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30), 
                Path = "/", 
                Secure = true, 
                HttpOnly = true 
            };
            Response.Cookies.Append("Username", username, cookieOptions);
            Response.Cookies.Append("SignUpTime", signUpTime, cookieOptions);

            return RedirectToAction("Dashboard", new { user = username });
        }

        public IActionResult Dashboard(string user)
        {
            string username = HttpContext.Session.GetString("Username")!;
            string SignUpTime = HttpContext.Session.GetString("SignUpTime")!;
            if (user != username)
            {
                Response.Cookies.Delete("Username");
                Response.Cookies.Delete("SignUpTime");
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            ViewData["user"] = username;
            ViewData["time"] = SignUpTime;

            return View();
        }
    }
}