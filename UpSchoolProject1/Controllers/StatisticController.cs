using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class StatisticController : Controller
    {

        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();
        public ActionResult Index()
        {
            ViewBag.countTestimonial = db.TblTestimonial.Count();  //Kayıtlardaki referansların sayısı
            ViewBag.countTestimonialCity = db.TblTestimonial.Where(x => x.City == "İstanbul").Count(); //Kayıtlardaki city değeri 'İstanbul' olanların sayısı
            ViewBag.countTestimonialProf = db.TblTestimonial.Where(x => x.Profession != "Yazılım Mühendisi").Count(); //Kayıtlardaki profession değeri 'Yazılım Mühendisi' olmayanların sayısı
            ViewBag.countTestimonialCityTrabzon = db.TblTestimonial.Where(x => x.City == "Trabzon").Select(x => x.NameSurname).FirstOrDefault();
            ViewBag.countAverage = db.TblTestimonial.Average(x => x.Balance); //Kayıtlardaki maaşların ortalaması
            return View();
        }
    }
}