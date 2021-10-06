using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class MessageController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Message
        public ActionResult Index()
        {
            var userMail = (string)Session["mail"].ToString();
            var messages = libraryEntities.Messages.Where(m => m.RECEIVER == userMail).ToList();
            return View(messages);
        }

        //yollanan mesajlar
        public ActionResult SendingMessage()
        {
            var userMail = (string)Session["mail"].ToString();
            var messages = libraryEntities.Messages.Where(m => m.SENDER == userMail).ToList();
            return View(messages);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Messages message)
        {
            var userMail = (string)Session["mail"].ToString();
            message.SENDER = userMail;
            message.DATE_ = DateTime.Parse(DateTime.Now.ToShortDateString());
            libraryEntities.Messages.Add(message);
            libraryEntities.SaveChanges();
            return RedirectToAction("SendingMessage", "Message");
        }

    }
}