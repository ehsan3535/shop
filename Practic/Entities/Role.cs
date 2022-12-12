using Microsoft.AspNetCore.Identity;

namespace practic.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
