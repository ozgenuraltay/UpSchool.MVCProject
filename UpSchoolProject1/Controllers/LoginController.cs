using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class LoginController : Controller
    {
        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblMember member)
        {
            var members = db.TblMember.FirstOrDefault(x=>x.MemberMail==member.MemberMail&& x.MemberPassword==member.MemberPassword);

            if (members!=null)
            {
                FormsAuthentication.SetAuthCookie(members.MemberMail, false); //remember me olacaksa true, olmayacaksa false olacak
                Session["MemberMail"] = member.MemberMail;
                return RedirectToAction("Index","About");
            }
            else
            {
            return RedirectToAction("Index");
            }
        }
    }
}