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
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddCategory(Categories category)
        {
            libraryEntities.Categories.Add(category); //kategoriyi ekledim
            libraryEntities.SaveChanges(); //değişikleri kaydettim
            return RedirectToAction("Index");
        }

        //kategori silme işlemleri
        public ActionResult DeleteCategory(int id)
        {
            var category = libraryEntities.Categories.Find(id);
            libraryEntities.Categories.Remove(category);
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        //kategoriyi getiren metot
        public ActionResult GetCategory(int id)
        {
            var category = libraryEntities.Categories.Find(id);
            return View("GetCategory", category);
        }

        //kategoriyi güncelleyen metot
        public ActionResult UpdateCategory(Categories category)
        {
            var cat = libraryEntities.Categories.Find(category.ID);
            cat.NAME = category.NAME;
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}