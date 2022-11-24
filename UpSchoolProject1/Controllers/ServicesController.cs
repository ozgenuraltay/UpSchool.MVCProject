using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities; //modelimin tutulduğu dizin

namespace UpSchoolProject1.Controllers
{
    public class ServicesController : Controller
    {
        //EntityFramework metodları:
        //ToList()
        //Add()
        //Remove()
        //Where()

        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();
        public ActionResult Index()
        {
            var services=db.TblServices.ToList();
            return View(services);
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblServices services)
        {
            db.TblServices.Add(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteService(int id)
        {
            var value=db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var service = db.TblServices.Find(id);
            return View(service);
        }
         //Metod isimleri aynı olabilir ama hem metod ismi hem de parametreleri aynı olamaz.
        [HttpPost]
        public ActionResult UpdateService(TblServices services)
        {
            var service = db.TblServices.Find(services.ServicesID);
            service.Title = services.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}