using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = am.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            am.TUpdate(about);
            return RedirectToAction("Index", "Default");
        }
    }
}
