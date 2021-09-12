using LibraryWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace LibraryWeb.Controllers
{
    public class MemberController : Controller
    {
        LibraryEntities libraryEntities = new LibraryEntities();
        // GET: Member
        public ActionResult Index(int startPageNumber = 1)
        {
            
            //var members = libraryEntities.Members.ToList();
            var members = libraryEntities.Members.ToList().ToPagedList(startPageNumber, 10);
            return View(members);
        }

        //Yeni Üye ekleme
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Members member)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            libraryEntities.Members.Add(member); //kategoriyi ekledim
            libraryEntities.SaveChanges(); //değişikleri kaydettim
            return RedirectToAction("Index");
        }

        //üye silme işlemleri
        public ActionResult DeleteMember(int id)
        {
            var member = libraryEntities.Members.Find(id);
            libraryEntities.Members.Remove(member);
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        //üyeyi getiren metot
        public ActionResult GetMember(int id)
        {
            var member = libraryEntities.Members.Find(id);
            return View("GetMember", member);
        }

        //üyeyi güncelleyen metot
        public ActionResult UpdateMember(Members member)
        {
            if (!ModelState.IsValid)
            {
                return View("GetMember");
            }
            var fetchMember = libraryEntities.Members.Find(member.ID);
            fetchMember.NAME = member.NAME;
            fetchMember.SURNAME = member.SURNAME;
            fetchMember.MAIL = member.MAIL;
            fetchMember.USERNAME = member.USERNAME;
            fetchMember.PASSWORD = member.PASSWORD;
            fetchMember.SCHOOL = member.SCHOOL;
            fetchMember.PHONENUMBER = member.PHONENUMBER;
            fetchMember.PHOTO = member.PHOTO;
            libraryEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}