using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager fm = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = fm.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            fm.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
    }
}
