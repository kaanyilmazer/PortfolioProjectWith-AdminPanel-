using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList : ViewComponent
    {
        MessageUserManager messageUserManager = new MessageUserManager(new EfMessageUserDal());
        public IViewComponentResult Invoke()
        {
            string p = "kaan@gmail.com";
            var values = messageUserManager.GetListReceiverMessage(p).OrderByDescending(x => x.MessageUserID).Take(3).ToList();
            return View(values);
        }
    }
}
