using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult Active(int id)
        {
            var deger = abm.GetByID(id);
            deger.AboutStatus = true;
            abm.AboutUpdate(deger);
            return RedirectToAction("Index");
        }
        public ActionResult DeActive(int id)
        {
            var deger = abm.GetByID(id);
            deger.AboutStatus = false;
            abm.AboutUpdate(deger);
            return RedirectToAction("Index");
        }


    }
}