using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practic.Entities;

namespace Practic.Entities
{
    public class ApplicationDbContex : IdentityDbContext<User, Role, Guid>
    {

        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
            : base(options)
        {
        }
    }
}





