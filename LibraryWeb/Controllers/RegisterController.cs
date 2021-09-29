using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class RegisterController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();
        // GET: Register
        public ActionResult Index(Members member)
        {
            libraryEntities.Members.Add(member);
            libraryEntities.SaveChanges();
            return View();
        }
    }
}