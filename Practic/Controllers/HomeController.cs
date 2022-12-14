using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Practic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContex;

        public HomeController(ApplicationDbContext dbContex)
        {
            _dbContex = dbContex;
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
