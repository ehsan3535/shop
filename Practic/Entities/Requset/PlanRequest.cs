using Practic.Entities;
using System.Diagnostics;

namespace Shop.Entities.Requset
{
    public class PlanRequest
    {
        public Guid Id { get; set; }
        public string Weight { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
    }
}
