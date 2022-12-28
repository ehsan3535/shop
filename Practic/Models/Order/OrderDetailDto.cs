using Shop.Entities.Product;

namespace Shop.Models.Order
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public Products Products { get; set; }
        public Guid ProductId { get; set; }
        public OrdersDto Orders { get; set; }
        public Guid OrdersId { get; set; }
    }
}
