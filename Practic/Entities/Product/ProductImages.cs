namespace Shop.Entities.Product
{
    public class ProductImages
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string ImageLink { get; set; }
    }
}
