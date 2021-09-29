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
        public ActionResult ReturnTheBook(Transactions transaction)
        {
            var returnBook = libraryEntities.Transactions.Find(transaction.ID);
            DateTime fetchReturnDateTime = DateTime.Parse(returnBook.RETURNDATE.ToString());
            DateTime fetchHandedDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan elapsedTime = fetchHandedDateTime - fetchReturnDateTime;
            ViewBag.elapsedtime = Convert.ToInt32(elapsedTime.TotalDays)+1;
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