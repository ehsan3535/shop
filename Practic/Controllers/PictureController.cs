using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class PictureController : Controller
    {
    private readonly ApplicationDbContext context;
    private readonly IMapper mapper;
        public PictureController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult AddNewData()
        {

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
