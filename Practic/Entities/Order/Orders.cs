using Shop.Entities.Constants;
using Shop.Entities.Order;
using Shop.Entities.Product;
using Users.Entities;

public class Orders
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public OrderStatuses OrderStatuses { get; set; }
    public int TotalPrice { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}

