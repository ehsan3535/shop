using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class PictureController : Controller
    private readonly ApplicationDbContext Context;
    private readonly IMapper mapper;
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewData()
        {

            return View();
        }
    }
}
