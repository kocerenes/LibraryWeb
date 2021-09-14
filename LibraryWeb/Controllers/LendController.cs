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
            var transactions = libraryEntities.Transactions.Where(x => x.PROCCESS_CASE == false).ToList();
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

        //iade etme
        public ActionResult ReturnTheBook(int id)
        {
            var returnBook = libraryEntities.Transactions.Find(id);
            return View("ReturnTheBook", returnBook);
        }

        //ödünç işlemini güncelleme
        public ActionResult LendUpdate(Transactions transaction)
        {
            var fetchTransaction = libraryEntities.Transactions.Find(transaction.ID);
            fetchTransaction.HANDEDDATE = transaction.HANDEDDATE;
            fetchTransaction.PROCCESS_CASE = true;
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}