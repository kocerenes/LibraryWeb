using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class AuthorController : Controller
    {

        LibraryEntities libraryWeb = new LibraryEntities();

        // GET: Author
        public ActionResult Index()
        {
            var values = libraryWeb.Authors.ToList();
            return View(values);
        }

        //yazar ekleme
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Authors author)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            libraryWeb.Authors.Add(author);
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }

        //Silme işlemi
        public ActionResult DeleteAuthor(int id)
        {
            var author = libraryWeb.Authors.Find(id);
            libraryWeb.Authors.Remove(author);
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }

        //yazar bilgilerini getiren metot
        public ActionResult GetAuthor(int id)
        {
            var author = libraryWeb.Authors.Find(id);
            return View("GetAuthor", author);
        }

        //yazar bilgilerinin güncellendiği metot
        public ActionResult UpdateAuthor(Authors author)
        {
            var variableAuthor = libraryWeb.Authors.Find(author.ID);
            variableAuthor.NAME = author.NAME;
            variableAuthor.SURNAME = author.SURNAME;
            variableAuthor.DETAIL = author.DETAIL;
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}