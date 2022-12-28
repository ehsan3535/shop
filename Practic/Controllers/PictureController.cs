using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Images;
using Shop.Models;
using Shop.NewFolder;

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
        [HttpPost]
        public IActionResult AddNewData(TestDto dto)
        {
            var TestEntity = mapper.Map<Test>(dto);
            TestEntity.ImageLink = UploadImages.SaveFile(dto.File,"test");
            context.Add(TestEntity);
            context.SaveChanges();
            return View();
        }
        public IActionResult DataList()
        {
            var TestEntity = context.Tests.ToList();
            var model = mapper.Map<TestDto>(TestEntity);
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
