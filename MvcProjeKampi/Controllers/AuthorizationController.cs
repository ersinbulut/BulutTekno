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
    public class AuthorizationController : Controller
    {
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valuerole = (from x in adminmanager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.AdminRole,
                                                  Value = x.AdminID.ToString()
                                              }).ToList();

            ViewBag.vlc = valuerole;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            p.AdminStatus = true;
            p.AdminRole = ViewBag.vlc;
            adminmanager.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {//böylece ıd değişkeninden gelen parametre değerine göre ilgili satırın kayıtlarını categoryvalue
         //isimli değişkene atadık
            List<SelectListItem> valuerole = (from x in adminmanager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.AdminRole,
                                                      Value = x.AdminID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuerole;

            var adminvalue = adminmanager.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adminmanager.AdminUpdate(p);
            return RedirectToAction("Index");
        }

    }
}