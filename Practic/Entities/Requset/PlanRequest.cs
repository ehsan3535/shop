using System.Diagnostics;
using Users.Entities;

namespace Shop.Entities.Requset
{
    public class PlanRequest
    {
        public Guid Id { get; set; }
        public string Weight { get; set; }
        public Users.Entities.User User { get; set; }
        public Guid UserId { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
    }
}
