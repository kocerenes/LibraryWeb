using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class LendController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Lend
        public ActionResult Index()
        {
            var transactions = libraryEntities.Transactions.ToList();
            return View(transactions);
        }

        [HttpGet]
        public ActionResult Lend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Lend(Transactions transaction)
        {
            libraryEntities.Transactions.Add(transaction);
            libraryEntities.SaveChanges();
            return View();
        }
    }
}