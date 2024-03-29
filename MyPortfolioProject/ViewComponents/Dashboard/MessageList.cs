﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
     Context  c = new Context();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
       
        public IViewComponentResult Invoke()
        {



            //ViewBag.v1 = c.UserMessages.OrderByDescending(x => x.Date)
            //                .Select(y => y.Date)
            //                .First().ToShortDateString();
            var values = messageManager.TGetList();
            return View(values);
        }
    }
}