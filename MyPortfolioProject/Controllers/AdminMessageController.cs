using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyPortfolioProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        MessageUserManager messageUserManager = new MessageUserManager(new EfMessageUserDal());
        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "kaan@gmail.com";
            var values = messageUserManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "kaan@gmail.com";
            var values = messageUserManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = messageUserManager.TGetByID(id);
            return View(values);
        }
        public IActionResult DeleteAdminMessage(int id)
        {
            var values = messageUserManager.TGetByID(id);
            messageUserManager.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();

        }
        [HttpPost]
        public IActionResult SendMessage(MessageUser p)
        {
            p.Sender = "kaan@gmail.com";
            p.SenderName = "Kaan Yılmazer";
            p.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x=>x.Email == p.Receiver).Select(y=>y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            messageUserManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
