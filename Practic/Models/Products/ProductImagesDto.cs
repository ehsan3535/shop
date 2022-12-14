namespace Shop.Models.Products
{
    public class ProductImagesDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public string ImageLink { get; set; }
    }
}
