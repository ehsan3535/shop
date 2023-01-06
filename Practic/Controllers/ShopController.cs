using Microsoft.AspNetCore.Mvc;
using Shop.Entities.Product;
using Microsoft.Win32.SafeHandles;
using AutoMapper;
using Shop.Models.ProductsDto;
using Shop.NewFolder;
using Shop.Images;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public ShopController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public IActionResult AddProduct()
        {
            var model = new ProductDto();
            var Categories = dbContext.Categorys.ToList();

            model.Categories = mapper.Map<List<CategoryDto>>(Categories);


            return View(model);
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto dto)
        {
            var product = mapper.Map<Products>(dto);
            product.CategoryId = dto.CategoryId;
            dbContext.Add(product);
            dbContext.SaveChanges();

            foreach (var item in dto.ProductImages)
            {
                var picture = new ProductImages()
                {
                    ImageLink = UploadImages.SaveFile(item, "ProductImages"),
                    ProductId = product.Id
                };
                dbContext.Add(picture);
            }

            return RedirectToAction(nameof(ProductList));
        }

        public IActionResult ProductList()
        {
            var products = dbContext.Products.ToList();
            if (Product != null)
            {
                var model = mapper.Map<List<ProductDto>>(products);
                return View(model);
            }
            return RedirectToAction(nameof(ProductList));

        }
        public IActionResult ProductDetail(Guid ProductId)
        {
            var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = mapper.Map<ProductDto>(Product);

                return View(model);
            }
            return RedirectToAction(nameof(ProductList));
        }
        public IActionResult EditProduct(Guid ProductId)
        {
            var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = mapper.Map<ProductDto>(Product);
                return View(model);
            }
            return RedirectToAction(nameof(ProductList));
        }
        [HttpPost]
        public IActionResult EditProduct(ProductDto dto)
        {
            var Product = dbContext.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (Product != null)
            {
                Product = mapper.Map<Products>(dto);

                dbContext.Update(Product);
                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(ProductList));
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult delete(Guid Id)
        {
            var Product = dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            dbContext.Products.Remove(Product);
            dbContext.SaveChanges();

            return RedirectToAction("ProductList");
        }
        public IActionResult Shop()
        {
            var products = dbContext.Products.ToList();
            if (products != null)
            {
                var model = mapper.Map<List<ProductDto>>(products);

                return View(model);
            }
            return RedirectToAction();


        }
        public IActionResult ProductDetail_User(Guid ProductId)
        {
            var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = mapper.Map<ProductDto>(Product);
                return View(model);
            }
            return RedirectToAction(nameof(Shop));
        }
    }
}
