using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
