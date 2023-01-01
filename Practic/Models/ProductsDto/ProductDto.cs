using Shop.Entities.Product;

namespace Shop.Models.ProductsDto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string weight { get; set; }
        public string Detail { get; set; }
        public string Test { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public string mojod { get; set; }
        public int Count { get; set; }
        public Guid SameProduct1Id { get; set; }
        public Guid SameProduct2Id { get; set; }
        public Guid SameProduct3Id { get; set; }
        public string? Rate { get; set; }
        public List<IFormFile> ProductImages { get; set; }
        public List<ProductCommentDto> ProductComments { get; set; }
         public List<CategoryDto> Categories { get; set; }
        public Guid CategoryId { get; set; }


        public ProductDto()
        {
            ProductImages = new List<IFormFile>();
            ProductComments = new List<ProductCommentDto>();
            Categories = new List<CategoryDto>();
        }


    }
}
