using Shop.Entities.Admin;

namespace Shop.Entities.Order
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public string Price { get; set; }
        public int Count { get; set; }
        public Product.Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Orders Orders { get; set; }
        public Guid OrdersId { get; set; }
    }
}
