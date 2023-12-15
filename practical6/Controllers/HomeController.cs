namespace practical6.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<Employee> allEmployees = new()
            {
                new Manager { Id = 1, Name = "Ramesh Soni", HiredDate = DateTime.Now, Department = "IT" },
                new Clerk { Id = 2, Name = "Jay Kumar", Office = "Reception" }
            };

            return View(allEmployees);
        }
    }
}