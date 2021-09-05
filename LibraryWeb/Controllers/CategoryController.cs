using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        LibraryEntities libraryEntities = new LibraryEntities();
        public ActionResult Index()
        {
            var values = libraryEntities.Categories.ToList();
            return View(values);


        }
    }
}