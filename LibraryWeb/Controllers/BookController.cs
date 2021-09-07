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
        public ActionResult Index(string receivedBook)
        {
            var book = from b in libraryWeb.Books select b;
            //arama yapılırsa
            if (!string.IsNullOrEmpty(receivedBook))
            {
                book = libraryWeb.Books.Where(n => n.NAME.Contains(receivedBook));
            }
            //var bookObject = libraryWeb.Books.ToList();
            return View(book.ToList());
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

        // kitap silme
        public ActionResult DeleteBook(int id)
        {
            var book = libraryWeb.Books.Find(id);
            libraryWeb.Books.Remove(book);
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }

        //kitap bilgilerini getirmek için
        public ActionResult GetBook(int id)
        {
            var book = libraryWeb.Books.Find(id);

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

            return View("GetBook", book);
        }

        //kitap güncelleme metodu
        public ActionResult UpdateBook(Books book)
        {
            var fetchBook = libraryWeb.Books.Find(book.ID);
            var fetchCategory = libraryWeb.Categories.Where(c => c.ID == book.Categories.ID).FirstOrDefault();
            var fetchAuthor = libraryWeb.Authors.Where(a => a.ID == book.Authors.ID).FirstOrDefault();
            fetchBook.NAME = book.NAME;
            fetchBook.CATEGORY = fetchCategory.ID;
            fetchBook.AUTHOR = fetchAuthor.ID;
            fetchBook.YEAROFPRINTING = book.YEAROFPRINTING;
            fetchBook.PUBLISHINGHOUSE = book.PUBLISHINGHOUSE;
            fetchBook.PAGE = book.PAGE;
            libraryWeb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}