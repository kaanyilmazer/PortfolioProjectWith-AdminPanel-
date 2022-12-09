using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Areas.User.ViewComponents
{
    public class Notification:ViewComponent

    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
