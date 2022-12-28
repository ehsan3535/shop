using Microsoft.AspNetCore.Mvc;
using Shop.Entities.Product;
using Microsoft.Win32.SafeHandles;
using AutoMapper;
using Shop.Models.ProductsDto;
using Shop.NewFolder;
using Shop.Images;
using Shop.Models;

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
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto dto)
        {
            var product = mapper.Map<Products>(dto);
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

            var model = new List<ProductDto>();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    var productdto = new ProductDto()
                    {
                        Id = product.Id,
                        Number = product.Number,
                        Name = product.Name,
                        Brand = product.Brand,
                        Price = product.Price,
                        Category = product.Category,
                        Count = product.Count,
                        Detail = product.Detail,
                        Test = product.Test,
                        mojod=product.mojod,
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
                    Number = Product.Number,
                    Brand = Product.Brand,
                    Category = Product.Category,
                    Price = Product.Price,
                    Name = Product.Name,
                    Count = Product.Count,
                    Detail = Product.Detail,
                    Test = Product.Test,
                    mojod = Product.mojod,
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
                    Number = Product.Number,
                    Brand = Product.Brand,
                    Category = Product.Category,
                    Price = Product.Price,
                    Name = Product.Name,
                    Count = Product.Count,
                    Detail = Product.Detail,
                    Test = Product.Test,
                    mojod = Product.mojod,
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
            //why?(just below sentenc)
            dto.Id = Guid.Parse(TempData["ProductId"].ToString());
            var Product = dbContext.Products.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (Product != null)
            {
                Product.Number = dto.Number;
                Product.Brand = dto.Brand;
                Product.Category = dto.Category;
                Product.Price = dto.Price;
                Product.Name = dto.Name;
                Product.Count = dto.Count;
                Product.Detail = dto.Detail;
                Product.Test = dto.Test;
                Product.mojod = dto.mojod;
                Product.weight = dto.weight;

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

            var model = new List<ProductDto>();

            if (products.Any())
            {
                foreach (var product in products)
                {
                    var productdto = new ProductDto()
                    {
                        Id = product.Id,
                        Number = product.Number,
                        Name = product.Name,
                        Brand = product.Brand,
                        Price = product.Price,
                        Category = product.Category,
                        Count = product.Count,
                        Detail = product.Detail,
                        Test = product.Test,
                        mojod = product.mojod,
                        weight = product.weight,

                    };
                    model.Add(productdto);

                }
                return View(model);
            }
            return View(model);


        }
        public IActionResult ProductDetail_User(Guid ProductId)
        {
              var Product = dbContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            if (Product != null)
            {
                var model = new ProductDto()
                {
                    Id = Product.Id,
                    Number = Product.Number,
                    Brand = Product.Brand,
                    Category = Product.Category,
                    Price = Product.Price,
                    Name = Product.Name,
                    Count = Product.Count,
                    Detail = Product.Detail,
                    Test = Product.Test,
                    mojod = Product.mojod,
                    weight = Product.weight,
                };
                return View(model);
            }
            return RedirectToAction(nameof(Shop));
        }
    }
}
