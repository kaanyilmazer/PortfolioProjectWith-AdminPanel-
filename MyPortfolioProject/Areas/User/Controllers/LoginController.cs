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
    public class LoginController : Controller
    {
        private readonly SignInManager<AspUser> _signInManager;

        public LoginController(SignInManager<AspUser> signInManager)
        {
            _signInManager = signInManager;
        }
         
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Default");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }

    }
}
