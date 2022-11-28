using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class VisitList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
