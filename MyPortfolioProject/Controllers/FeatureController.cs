using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
