using Microsoft.AspNetCore.Identity;

namespace practic.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string description { get; set; }
    }
}
