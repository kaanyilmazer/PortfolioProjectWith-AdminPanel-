using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Areas.User.Models;

namespace MyPortfolioProject.Areas.User.Controllers
{
    [AllowAnonymous]
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AspUser> _userManager;
        //private readonly RoleManager<UserRole> _roleManager;
        public RegisterController(UserManager<AspUser> userManager)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }
        

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {

            var user = new AspUser
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                ImageUrl = p.ImageUrl
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, UserRole.User);
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }}}
//Kaan_1234