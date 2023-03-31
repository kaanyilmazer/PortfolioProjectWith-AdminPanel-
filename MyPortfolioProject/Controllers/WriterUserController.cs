using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyPortfolioProject.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager userManager = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(userManager.TGetList());
            return Json(values);

        }
        [HttpPost]
        public IActionResult AddUser(AspUser p)
        {
            userManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

    }
}
