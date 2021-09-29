using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Models.Classes;

namespace LibraryWeb.Controllers
{
    public class ShowcaseController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();
        // GET: Showcase
        [HttpGet]
        public ActionResult Index()
        {
            Enumerable_ enumerable = new Enumerable_();
            enumerable.bookValues = libraryEntities.Books.ToList();
            enumerable.aboutUsValues = libraryEntities.AboutUs.ToList();
            //var bookValues = libraryEntities.Books.ToList();
            return View(enumerable);
        }
        [HttpPost]
        public ActionResult Index(Communicates communicate)
        {
            libraryEntities.Communicates.Add(communicate);
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}