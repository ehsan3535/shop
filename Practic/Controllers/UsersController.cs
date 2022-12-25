using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System.Xml.Linq;
using Users.Entities;

namespace Users.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext dbContex;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly SignInManager<User> signInManager;

        public UsersController(ApplicationDbContext dbContex, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            this.dbContex = dbContex;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public IActionResult AddUser()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UsersDto Dto)
        {
            var FindUser = await userManager.Users.Where(x => x.UserName == Dto.Username).FirstOrDefaultAsync();
            if (FindUser != null)
            {
                return View(nameof(eror2));
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
                var FindRole = await roleManager.FindByNameAsync("Username");
                if (FindRole != null)
                {
                    var Role = new Role()
                    {
                        Name = "Username",
                        Description = "this is a normal user"
                    };
                    await roleManager.CreateAsync(Role);
                }
            }
            await userManager.AddToRoleAsync(User, "Username");


            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UsersDto dto , string password)
        {
            var User = await userManager.FindByNameAsync(dto.Username);

            if (User != null)

            {
                var Status = await signInManager.PasswordSignInAsync(User, password , true, true);
                if (Status.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                return View(nameof(eror3));

            }
            return RedirectToAction("eroe2");

        }
        [Authorize]
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
        public IActionResult Dashboard_Admin()
        {
            return View();
        }
        /*        [Authorize(Roles = "Admin")]
        */
        public async Task<IActionResult> Promote(Guid UserId)
        {
            var User = await userManager.FindByIdAsync(UserId.ToString());

            if (User != null)
            {
                var Role = await roleManager.FindByNameAsync("Admin");
                if (Role == null)
                {
                    Role = new Role()
                    {
                        Name = "Admin"
                    };
                    await roleManager.CreateAsync(Role);
                }
                await userManager.AddToRoleAsync(User, Role.Name);
            }
            return RedirectToAction();
        }
        public async Task<IActionResult> UserDetail()
        {
            var user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var model = new UsersDto()
            {
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Username = user.UserName,
                Email = user.Email,
                NationalCode = user.NationalCode,
            };

            return View(model);
        }
        public IActionResult EditUser(Guid UserId)
        {
            var user = dbContex.Users.Where(x => x.Id == UserId).FirstOrDefault();
            if (user != null)
            {
                var model = new UsersDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    NationalCode = user.NationalCode,
                    PhoneNumber = user.PhoneNumber,
                    Username = user.UserName,
                };
                TempData["UserId"] = UserId;
                return View(model);
            }
            return RedirectToAction(nameof(ListUser));
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UsersDto dto)
        {
            dto.Id = Guid.Parse(TempData["UserId"].ToString());
            var user = await userManager.FindByIdAsync(dto.Id.ToString());

            var Finduser = await userManager.Users.Where(x => x.Id != dto.Id && x.UserName == dto.Username)
                .FirstOrDefaultAsync();
            if (Finduser != null)
            {
                return View();
            }

            user.Name = dto.Name;
            user.UserName = dto.Username;
            user.Email = dto.Email;
            user.NationalCode = dto.NationalCode;
            user.PhoneNumber = user.PhoneNumber;

            await userManager.UpdateAsync(user);

            return RedirectToAction("ListUser");
        }
        public IActionResult ListUser()
        {
            var user = dbContex.Users.ToList();
            var model = new List<UsersDto>();
            foreach (var item in user)
            {
                var ListUser = new UsersDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    NationalCode = item.NationalCode,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Username = item.UserName,
                };
                model.Add(ListUser);
            };
            return View(model);
        }
    }
}
