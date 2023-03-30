using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MyPortfolioProject.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AspUser> _userManager;

        public DashboardController(UserManager<AspUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = values.Name + " " + values.Surname;

            //WeatherAPI
            string api = "cf6545a2d08cfdc8d8eb36f1015a4d41";
            string con = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(con);
            ViewBag.v7 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //Statistics
            Context c = new Context();
            ViewBag.v2 = c.MessageUsers.Where(u => u.Receiver == values.Email).Count();
            ViewBag.v4 = c.Users.Count();
            ViewBag.v5 = c.Skills.Count();
            ViewBag.v6 = c.Announcements.OrderBy(x => x.ID)
                            .Select(y => y.Content)
                            .LastOrDefault();
            ViewBag.v3 = c.Announcements.Count();
            return View();
        }
    }
}
