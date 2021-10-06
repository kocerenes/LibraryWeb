using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryWeb.Controllers
{
    public class LoginController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Login
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Members member)
        {
            var memberLoginInfo = libraryEntities.Members.FirstOrDefault(m => m.MAIL == member.MAIL && m.PASSWORD == member.PASSWORD);

            if (memberLoginInfo != null)
            {
                FormsAuthentication.SetAuthCookie(memberLoginInfo.MAIL, false);
                Session["mail"] = memberLoginInfo.MAIL.ToString();
                Session["name"] = memberLoginInfo.NAME.ToString();
                Session["surname"] = memberLoginInfo.SURNAME.ToString();
                //TempData["id"] = memberLoginInfo.ID.ToString();
                //TempData["name"] = memberLoginInfo.NAME.ToString();
                //TempData["surname"] = memberLoginInfo.SURNAME.ToString();
                //TempData["username"] = memberLoginInfo.USERNAME.ToString();
                //TempData["password"] = memberLoginInfo.PASSWORD.ToString();
                //TempData["school"] = memberLoginInfo.SCHOOL.ToString();
                return RedirectToAction("Index", "StudentPage");
            }
            else
            {
                return View();
            }
        }
    }
}