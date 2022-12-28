using Microsoft.AspNetCore.Mvc;
using Shop.Models.Order;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //public IActionResult AddOrder()
        //{
        //    return View();
        //}
        //public IActionResult AddOrder(OrdersDto dto)
        //{
        //    var Order = new Orders()
        //    {
        //        Id = dto.Id,
        //        OrderDetails = (ICollection<Entities.Order.OrderDetail>)dto.OrderDetails,
        //        OrderStatuses = dto.OrderStatuses,
        //        TotalPrice = dto.TotalPrice,

        //    };
        //    dbContext.Add(Order);
        //    dbContext.SaveChanges();
        //    return View();
        //}
        public IActionResult ListOrders(Guid OrderId)
        {
            var order = dbContext.Orders.ToList();

            var model = new List<OrdersDto>();

            if (order.Any())
            {
                foreach (var item in order)
                {
                    var orderdto = new OrdersDto()
                    {
                        Id = item.Id,
                        OrderStatuses = item.OrderStatuses,
                        TotalPrice = item.TotalPrice,
                        ProductId = item.ProductId,
                        User = item.User,
                    };
                    model.Add(orderdto);

                }
                return View(model);
            }
            return View(model);


        }
    }
}
