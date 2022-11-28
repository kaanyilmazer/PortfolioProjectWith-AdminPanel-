using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class Last5Project:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
