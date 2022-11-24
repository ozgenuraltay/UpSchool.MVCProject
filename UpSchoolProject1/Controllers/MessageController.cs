using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpSchoolProject1.Models.Entities;

namespace UpSchoolProject1.Controllers
{
    public class MessageController : Controller
    {
        UpSchoolFirstDBEntities db = new UpSchoolFirstDBEntities();

        public ActionResult Inbox()
        {
            var mail = Session["MemberMail"].ToString();
            var messages = db.TblMessage.Where(x => x.ReceiverMail == mail).ToList();
            return View(messages);
        }

        public ActionResult Outbox()
        {
            var mail = Session["MemberMail"].ToString();
            var messages = db.TblMessage.Where(x => x.SenderMail == mail).ToList();
            return View(messages);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage message)
        {
            var mail = Session["MemberMail"].ToString();

            message.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            message.SenderMail = mail;
            db.TblMessage.Add(message);
            message.SenderNameSurname = db.TblMember.Where(x => x.MemberMail == mail).Select(x => x.MemberName + " " + x.MemberSurname).FirstOrDefault();
            message.ReceiverNameSurname = db.TblMember.Where(x => x.MemberMail == message.ReceiverMail).Select(x => x.MemberName + " " + x.MemberSurname).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("Outbox");
        }

        public ActionResult MessageDetails()
        {
            return View();
        }
    }
}