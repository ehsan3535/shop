using Shop.Entities.Product;

namespace Shop.Entities.Product
{
    public class ProductImages
    {
        public Guid Id { get; set; }

        public Products Product { get; set; }
        public Guid ProductId { get; set; }

        public string ImageLink { get; set; }
    }
}
