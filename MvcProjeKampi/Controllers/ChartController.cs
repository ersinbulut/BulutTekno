using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName="Yazılım",
                CategoryCount=8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Seyehat",
                CategoryCount = 4
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }

        //----------------
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult HeadingChart()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

        public List<HeadingClass> HeadingList()
        {
            List<HeadingClass> ct = new List<HeadingClass>();
            ct.Add(new HeadingClass()
            {
                HeadingName = "Breaking Bad",
                HeadingCount = 3
            });
            ct.Add(new HeadingClass()
            {
                HeadingName = "Green Book",
                HeadingCount = 1
            });

            return ct;
        }
    }
}