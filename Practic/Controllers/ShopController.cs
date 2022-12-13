using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practic.Entities;
using Practic.Entities;
using Shop.Models;
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

        [HttpPost]
        public async Task<IActionResult> AddUser(ShopDto Dto)
        {
            Dto.PhoneNumber = Dto.Username;
            if (ModelState.IsValid)
            {
                var FindUser = await userManager.Users.Where(x => x.UserName == Dto.Username).FirstOrDefaultAsync();
                if (FindUser != null)
                {
                    ModelState.AddModelError("Username", "کاربر تکراری است");
                    return RedirectToAction("index", "home");
                }
                var User = new User()
                {
                    Id = Dto.Id,
                    Name = Dto.Name,
                    Email = Dto.Email,
                    NationalCode = Dto.NationalCode,
                    PhoneNumber = Dto.PhoneNumber,
                    UserName = Dto.Username,
                };
                var status = await userManager.CreateAsync(User, Dto.Password);
                if (status.Succeeded)
                {
                    var FindRole = await roleManager.FindByNameAsync("NormalUser");
                    if (FindRole == null)
                    {
                        var Role = new Role()
                        {
                            Name = "NormalUser",
                            Description = "this is a normal user"
                        };
                        await roleManager.CreateAsync(Role);
                    }
                }
                await userManager.AddToRoleAsync(User, "NormalUser");


            }
            return RedirectToAction("index", "home");
        }
       
        [HttpPost]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            var User = await userManager.FindByNameAsync(Username);
            if (User != null)
            {
                var Status = await signInManager.PasswordSignInAsync(User, Password, true, true);
                if (Status.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                return View(nameof(eror3));
            }
            return RedirectToAction("eroe2");

        }
        public async Task<IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");

        }
        public async Task<IActionResult> Rolelist(Guid UserId)
        {
            var ListRole = dbContex.Roles.ToList();
            var list = new List<string>();
            foreach (var item in ListRole)
            {
                list.Add(item.Name);
            }
            TempData["UserId"] = UserId;

            return View(list);
        }
        public async Task<IActionResult> ChoseList(string Role)
        {
            TempData["UserId"].ToString();
            var user = await userManager.FindByIdAsync(TempData["UserId"].ToString());
            await userManager.AddToRoleAsync(user, Role);

            return View();
        }
        public async Task<IActionResult> eror2()
        {

            return View();
        }
        public async Task<IActionResult> eror3()
        {

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
