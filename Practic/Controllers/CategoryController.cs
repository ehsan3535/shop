using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Entities.Product;
using Shop.Models;
using Shop.Models.ProductsDto;

namespace Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CategoryController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDto dto)
        {
            var Category = mapper.Map<Category>(dto);
            dbContext.Add(Category);
            dbContext.SaveChanges();

            return View();
        }
        public IActionResult CategoryList()
        {
            var model = new List<CategoryDto>();
            var Category = dbContext.Categorys.ToList();
            if (Category.Any())
            {
                model = mapper.Map<List<CategoryDto>>(Category);
                return View(model);
            }
            return View(model);

        }

        public IActionResult EditCategory(Guid CategoryId)
        {
            var model = new CategoryDto();

            var Category = dbContext.Categorys.Where(x => x.Id == CategoryId).FirstOrDefault();
            if (Category != null)
            {
                 model = mapper.Map<CategoryDto>(Category);

                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryDto dto)
        {
            var Category = dbContext.Categorys.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (Category != null)
            {
                Category = mapper.Map<Category>(dto);


                dbContext.Update(Category);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(CategoryList));
        }
        public IActionResult delete(Guid Id)
        {
            var category = dbContext.Categorys.Where(x => x.Id == Id).FirstOrDefault();
            dbContext.Categorys.Remove(category);
            dbContext.SaveChanges();

            return RedirectToAction("CategoryList");
        }

    }
}
