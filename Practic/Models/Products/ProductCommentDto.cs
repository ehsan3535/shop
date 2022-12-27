using Users.Entities;

namespace Shop.Models.Products
{
    public class ProductCommentDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public Guid UserId { get; set; }
        public Users.Entities.User Users { get; set; }
    }
}
