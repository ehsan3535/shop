using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practic.Entities;
using Practic.Models;
using System.Diagnostics;

namespace Practic.Controllers
{
    public class HomeController : Controller
    { 
         private readonly ApplicationDbContex _dbContex;

    public HomeController(ApplicationDbContex dbContex)
    {
        _dbContex = dbContex;
    }
    

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
    