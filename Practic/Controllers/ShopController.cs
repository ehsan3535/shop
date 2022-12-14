﻿using Microsoft.AspNetCore.Mvc;
using Shop.Models.Products;
using Shop.Entities.Product;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ShopController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto dto)
        {
            var Product = new Product()
            {
                Name = dto.Name,
                Detail = dto.Detail,
                Brand = dto.Brand,
                Category = dto.Category,
                Count = dto.Count,
                Price = dto.Price,
                Rate = dto.Rate,
                Test = dto.Test,
                weight = dto.weight,

            };
            dbContext.Add(Product);
            dbContext.SaveChanges();


            return RedirectToAction(nameof(ProductList));
        }
        public IActionResult ProductList()
        {
            var products = dbContext.Products.ToList();

            var model = new List<ProductDto>();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    var productdto = new ProductDto()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Brand = product.Brand,
                        Price = product.Price,
                        Category = product.Category,
                        Count = product.Count,
                        Rate = product.Rate,
                        Detail = product.Detail,
                        Test = product.Test,
                        weight = product.weight,

                    };
                    model.Add(productdto);

                }
                return View(model);
            }
            return View(model);

        }
        public IActionResult ProductDetail(Guid ProductId)
        {
            var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = new ProductDto()
                {
                    Id = Product.Id,
                    Brand = Product.Brand,
                    Category = Product.Category,
                    Price = Product.Price,
                    Name = Product.Name,
                    Count = Product.Count,
                    Detail = Product.Detail,
                    Rate = Product.Rate,
                    Test = Product.Test,
                    weight = Product.weight,
                };
                return View(model);
            }
            return RedirectToAction(nameof(ProductList));
        }
        public IActionResult EditProduct(Guid ProductId)
        {
            var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = new ProductDto()
                {
                    Id = Product.Id,
                    Brand = Product.Brand,
                    Category = Product.Category,
                    Price = Product.Price,
                    Name = Product.Name,
                    Count = Product.Count,
                    Detail = Product.Detail,
                    Rate = Product.Rate,
                    Test = Product.Test,
                    weight = Product.weight,
                };
                TempData["ProductId"] = ProductId;
                return View(model);
            }
            return RedirectToAction(nameof(ProductList));
        }
        [HttpPost]
        public IActionResult EditProduct(ProductDto dto)
        {
            dto.Id = Guid.Parse(TempData["ProductId"].ToString());
            var Product = dbContext.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (Product != null)
            {
                Product.Brand = dto.Brand;
                Product.Category = dto.Category;
                Product.Price = dto.Price;
                Product.Name = dto.Name;
                Product.Count = dto.Count;
                Product.Detail = dto.Detail;
                Product.Rate = dto.Rate;
                Product.Test = dto.Test;
                Product.weight = dto.weight;

                dbContext.Update(Product);

                dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(ProductList));
        }
    }
}
