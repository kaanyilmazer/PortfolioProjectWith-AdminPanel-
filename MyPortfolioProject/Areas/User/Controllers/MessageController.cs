using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Message")]
    public class MessageController : Controller
    {
        MessageUserManager messageUserManager = new MessageUserManager(new EfMessageUserDal());
        private readonly UserManager<AspUser> _userManager;

        public MessageController(UserManager<AspUser> userManager)
        {
            _userManager = userManager;
        }


        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageUserManager.GetListReceiverMessage(p);
            return View(messageList);
        }


        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageUserManager.GetListSenderMessage(p);
            return View(messageList);
        }


        [Route("MessageDetails/{id}")]
        public IActionResult MessageDetails(int id)
        {
            MessageUser messageUser = messageUserManager.TGetByID(id);
            return View(messageUser);
        }


        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            MessageUser messageUser = messageUserManager.TGetByID(id);
            return View(messageUser);
        }


        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }


        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task <IActionResult> SendMessage(MessageUser p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email==p.Receiver).Select(y=>y.Name+" "+y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            messageUserManager.TAdd(p);
            return RedirectToAction("SenderMessage");

        }
    }
}
