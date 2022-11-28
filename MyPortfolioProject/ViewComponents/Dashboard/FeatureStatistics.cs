using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.Messages.Where(x=>x.Status==false).Count();
            ViewBag.v3 = c.Messages.OrderByDescending(x => x.Date)
                            .Select(y => y.Date)
                            .First().ToShortDateString();

            ViewBag.v4 = c.Experiences.Count();
            return View();
        }
    }
}
