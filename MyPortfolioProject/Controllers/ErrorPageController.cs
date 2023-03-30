using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
