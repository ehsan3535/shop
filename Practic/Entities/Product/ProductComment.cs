using Practic.Entities;

namespace Shop.Entities.Product
{
    public class ProductComment
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        public User Users { get; set; }

    }
}
