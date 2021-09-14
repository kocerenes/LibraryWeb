using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class ProcessingController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Proccess
        public ActionResult Index()
        {
            var processes = libraryEntities.Transactions.Where(t => t.PROCCESS_CASE == true).ToList();
            return View(processes);
        }
    }
}