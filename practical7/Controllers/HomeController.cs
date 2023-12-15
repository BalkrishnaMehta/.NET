using Microsoft.AspNetCore.Mvc;
using practical7.Extensions;

namespace practical7.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Employee emp1 = new()
            {
                Id = 1,
                Name = "John Doe",
                HiredDate = new DateTime(2022, 5, 15)
            };

            Employee emp2 = new()
            {
                Id = 2,
                Name = "Jane Smith",
            };

            List<string> employeesInfo = new()
            {
                emp1.GetEmployeeInfo(),
                emp2.GetEmployeeInfo()
            };

            return View(employeesInfo);
        }
    }
}