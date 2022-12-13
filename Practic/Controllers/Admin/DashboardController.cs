using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers.Admin
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
