using LibraryWeb.Models.Entity;
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

        //Yeni kategori ekleme
        public ActionResult AddCategory(Categories category)
        {
            libraryEntities.Categories.Add(category); //kategoriyi ekledim
            libraryEntities.SaveChanges(); //değişikleri kaydettim
            return View();
        }
    }
}