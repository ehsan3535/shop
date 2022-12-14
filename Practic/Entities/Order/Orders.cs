using Shop.Entities.Constants;
using Shop.Entities.Order;
using Users.Entities;

public class Orders
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
    public OrderStatuses OrderStatuses { get; set; }
    public int TotalPrice { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
}

