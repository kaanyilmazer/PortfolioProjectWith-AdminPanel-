using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Areas.User.ViewComponents
{
    public class Navbar:ViewComponent
    {
        private readonly UserManager<AspUser> _userManager;

        public Navbar(UserManager<AspUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.ImageUrl;
            return View();
        }
    }
}
