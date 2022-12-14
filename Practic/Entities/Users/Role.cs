using Microsoft.AspNetCore.Identity;

namespace Users.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
