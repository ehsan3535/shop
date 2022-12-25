using Shop.Entities.Constants;
using Shop.Entities.Product;
using Users.Entities;

namespace Shop.Models.Order
{
    public class OrdersDto
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public OrderStatuses OrderStatuses { get; set; }
        public int TotalPrice { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
