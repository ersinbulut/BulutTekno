using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();

        Context db = new Context();
        // GET: Admin/AdminContact
        public ActionResult Index()
        {
            var contactvalue = cm.GetList();
            return View(contactvalue);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contentvalues = cm.GetByID(id);
            return View(contentvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            var deger = db.Contacts.Count();
            ViewBag.deger = deger;
            var deger1 = db.Messages.Where(x => x.ReceiverMail == "admin@gmail.com").Count().ToString();//alıcı maili admin olanların sayısı
            ViewBag.deger1 = deger1;
            var deger2 = db.Messages.Where(x => x.SenderMail == "admin@gmail.com").Count().ToString();//gönderici maili admin olanların sayısı
            ViewBag.deger2 = deger2;
            return PartialView();
        }
    }
}