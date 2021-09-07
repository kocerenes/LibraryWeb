using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class BookController : Controller
    {
        LibraryEntities libraryWeb = new LibraryEntities();

        // GET: Book
        public ActionResult Index()
        {
            var bookObject = libraryWeb.Books.ToList();
            return View(bookObject);
        }

        //Kitap ekleme
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> valuesCategory = (from c in libraryWeb.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = c.NAME,
                                               Value = c.ID.ToString()
                                           }).ToList();
            ViewBag.fetchCategory = valuesCategory;

            List<SelectListItem> valuesAuthor = (from a in libraryWeb.Authors.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = a.NAME + " " + a.SURNAME,
                                                     Value = a.ID.ToString()
                                                 }).ToList();
            ViewBag.fetchAuthor = valuesAuthor;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Books book)
        {
            var category = libraryWeb.Categories.Where(c => c.ID == book.Categories.ID).FirstOrDefault();
            var author = libraryWeb.Authors.Where(a => a.ID == book.Authors.ID).FirstOrDefault();
            book.Categories = category;
            book.Authors = author;
            libraryWeb.Books.Add(book);
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}