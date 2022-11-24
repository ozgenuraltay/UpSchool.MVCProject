using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class UserController : Controller
    {
        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AboutPartial()
        {
            var about = db.TblAbout.ToList();
            return PartialView(about);
        }

        public PartialViewResult ServicePartial()
        {
            var services = db.TblServices.ToList();
            return PartialView(services);
        }

    }
}