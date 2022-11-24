using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class MemberController : Controller
    {
        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();

        public ActionResult Index()
        {
            var mail = Session["MemberMail"].ToString();
            var memberInformation = db.TblMember.Where(X => X.MemberMail == mail).FirstOrDefault();
            ViewBag.name = memberInformation.MemberName;
            ViewBag.surname = memberInformation.MemberSurname;
            ViewBag.id = memberInformation.MemberID;

            return View();
        }
    }
}