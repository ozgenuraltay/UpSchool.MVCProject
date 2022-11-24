using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class AboutController : Controller
    {
        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();

        [Authorize] //kullanıcı adı ve şifreyle ulaşılabilecek
        public ActionResult Index()
        {
            var abouts = db.TblAbout.ToList();
            return View(abouts);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbout about)
        {
            db.TblAbout.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
           var about= db.TblAbout.Find(id);
            db.TblAbout.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.TblAbout.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout abouts)
        {
            var about = db.TblAbout.Find(abouts.AboutID);
            about.Description = abouts.Description;
            about.ImageURL = abouts.ImageURL;
            about.NameSurname = abouts.NameSurname;
            about.Title = abouts.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}