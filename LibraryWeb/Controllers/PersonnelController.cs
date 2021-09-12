using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Controllers
{
    public class PersonnelController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();

        // GET: Personnel
        public ActionResult Index()
        {
            var personnels = libraryEntities.Personnels.ToList();
            return View(personnels);
        }

        //Yeni personel ekleme
        [HttpGet]
        public ActionResult AddPersonnel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPersonnel(Personnels personel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPersonnel");
            }
            libraryEntities.Personnels.Add(personel); //kategoriyi ekledim
            libraryEntities.SaveChanges(); //değişikleri kaydettim
            return RedirectToAction("Index");
        }

        //personel silme işlemleri
        public ActionResult DeletePersonnel(int id)
        {
            var personel = libraryEntities.Personnels.Find(id);
            libraryEntities.Personnels.Remove(personel);
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        //kategoriyi getiren metot
        public ActionResult GetPersonnel(int id)
        {
            var personel = libraryEntities.Personnels.Find(id);
            return View("GetPersonnel", personel);
        }

        //kategoriyi güncelleyen metot
        public ActionResult UpdatePersonnel(Personnels personel)
        {
            if (!ModelState.IsValid)
            {
                return View("GetPersonnel");
            }
            var fetchPersonnel = libraryEntities.Personnels.Find(personel.ID);
            fetchPersonnel.NAMESURNAME = personel.NAMESURNAME;
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}