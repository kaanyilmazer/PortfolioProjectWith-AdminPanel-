using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var values = sm.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            sm.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var values = sm.TGetByID(id);
            sm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var values = sm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            sm.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
