using Shop.Entities.Product;
using Users.Entities;

namespace Shop.Entities.Requset
{
    public class MokamelRequsets
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public Users.Entities.User User { get; set; }
        public Guid UserId { get; set; }
    }
}
