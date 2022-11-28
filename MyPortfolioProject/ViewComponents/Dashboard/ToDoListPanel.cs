using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        ToDoListManager toDolistmanager = new ToDoListManager(new EfToDoListDal());

        public IViewComponentResult Invoke()
        {
            var values = toDolistmanager.TGetList();
            return View(values);
        }
    }
}