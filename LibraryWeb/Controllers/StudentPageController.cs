using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class StudentPageController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: StudentPage
        [Authorize]
        public ActionResult Index()
        {
            var userMail = (string)Session["mail"];
            var valueOfMember = libraryEntities.Members.FirstOrDefault(m => m.MAIL == userMail);
            return View(valueOfMember);
        }
        //[HttpPost]
        //public ActionResult Index(Members member)
        //{
        //    var userMail = (string)Session["mail"];
        //    var memberMail = libraryEntities.Members.FirstOrDefault(m => m.MAIL == userMail);
        //    memberMail.PASSWORD = member.PASSWORD;
        //    libraryEntities.SaveChanges();
        //    return View();
        //}
        [HttpPost]
        public ActionResult UpdateUserInfo(Members member)
        {
            var userMail = (string)Session["mail"];
            var memberMail = libraryEntities.Members.FirstOrDefault(m => m.MAIL == userMail);
            memberMail.PASSWORD = member.PASSWORD;
            memberMail.PHOTO = member.PHOTO;
            memberMail.USERNAME = member.USERNAME;
            memberMail.SCHOOL = member.SCHOOL;
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MyBooks()
        {
            var userMail = (string)Session["mail"].ToString();
            var userID = libraryEntities.Members.Where(m => m.MAIL == userMail).Select(m => m.ID).FirstOrDefault();
            var values = libraryEntities.Transactions.Where(t => t.MEMBER == userID).ToList();
            return View(values);
        }
    }
}