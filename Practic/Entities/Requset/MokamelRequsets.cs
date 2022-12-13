using Practic.Entities;
using Shop.Entities.Product;

namespace Shop.Entities.Requset
{
    public class MokamelRequsets
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
