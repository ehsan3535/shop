namespace Shop.Models.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string weight { get; set; }
        public string Detail { get; set; }
        public string Test { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public Guid SameProduct1Id { get; set; }
        public ProductDto SameProduct1 { get; set; }
        public Guid SameProduct2Id { get; set; }
        public ProductDto SameProduct2 { get; set; }
        public Guid SameProduct3Id { get; set; }
        public ProductDto SameProduct3 { get; set; }
        public string Rate { get; set; }
        public ICollection<ProductImagesDto> ProductImages { get; set; }
        public ICollection<ProductCommentDto> ProductComments { get; set; }


    }
}
