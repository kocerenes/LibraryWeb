using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class StatisticController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Statistic
        public ActionResult Index()
        {
            return View();
        }

        //hava durumu
        public ActionResult Weather()
        {
            return View();
        }

        //güncel hava durumu
        public ActionResult WeatherCard()
        {
            return View();
        }

        //galeri
        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult LinqCard()
        {
            var bookCount = libraryEntities.Books.Count();
            var memberCount = libraryEntities.Members.Count();
            var totalCashFines = libraryEntities.Cash_fines.Sum(x => x.MONEY);
            var loanBook = libraryEntities.Books.Where(b => b.CASE_ == false).Count();
            var categoryCount = libraryEntities.Categories.Count();
            var mostWrittenAuthor = libraryEntities.MostWrittenAuthor().FirstOrDefault(); //sql procedure den cektim

            ViewBag.bookCount = bookCount;
            ViewBag.membercount = memberCount;
            ViewBag.totalCashFines = totalCashFines;
            ViewBag.loanBook = loanBook;
            ViewBag.categoryCount = categoryCount;
            ViewBag.mostWrittenAuthor = mostWrittenAuthor;
            return View();
        }
    }
}