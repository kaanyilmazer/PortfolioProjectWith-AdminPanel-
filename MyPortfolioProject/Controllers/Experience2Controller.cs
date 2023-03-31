using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyPortfolioProject.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);

        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID) { 
        var values = experienceManager.TGetByID(ExperienceID);
         var valuesi = JsonConvert.SerializeObject(values);
         return Json(valuesi);
        }

        public IActionResult DeleteExperience(int id)
        {
            var v = experienceManager.TGetByID(id);
            experienceManager.TDelete(v);
            return NoContent();
        }

        public IActionResult UpdateExperience(int id, string name, string date)
        {
            var findvalue = experienceManager.TGetByID(id);

            if (findvalue != null)
            {
                findvalue.ExperienceName = name;
                findvalue.Date = date;
                experienceManager.TUpdate(findvalue);
                var val = JsonConvert.SerializeObject(findvalue);

                return Json(val);
            }
            return NoContent();
        }
    }
}
