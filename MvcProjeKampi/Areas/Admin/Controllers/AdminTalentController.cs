using DataAccessLayer.Concrate;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminTalentController : Controller
    {
        Context db = new Context();
        // GET: Admin/AdminTalent
        public ActionResult Index()
        {
            var talent = db.Talents.ToList();
            return View(talent);
        }
        public ActionResult TalentList()
        {
            var talent = db.Talents.ToList();
            return View(talent);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent p)
        {
            db.Talents.Add(p);
            db.SaveChanges();
            return RedirectToAction("TalentList");
        }

        [HttpGet]
        public ActionResult EditTalent(int id)
        {//böylece ıd değişkeninden gelen parametre değerine göre ilgili satırın kayıtlarını categoryvalue
            //isimli değişkene atadık
            var categoryvalue = db.Talents.Find(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditTalent(Talent p)
        {
            db.Talents.Add(p);
            db.SaveChanges();
            return RedirectToAction("TalentList");
        }
        
   
        public ActionResult DeleteTalent(int id)
        {
            var deger = db.Talents.Find(id);
            db.Talents.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("TalentList");
        }
    }
}