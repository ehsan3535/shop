using Microsoft.AspNetCore.Identity;

namespace Users.Entities
{
    public class User : IdentityUser<Guid>

    {
        public string Name { get; set; }
        public string NationalCode { get; set; }
    }
}
