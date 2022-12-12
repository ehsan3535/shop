using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practic.Entities;
using Practic.Entities;

namespace Practic.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContex dbContex;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;

        public ShopController(ApplicationDbContex dbContex, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            this.dbContex = dbContex;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
