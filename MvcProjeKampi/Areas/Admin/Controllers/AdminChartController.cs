using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminChartController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        // GET: Admin/AdminChart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> cs2 = new List<CategoryClass>();
            using (var c = new Context())
            {
                cs2 = c.Categories.Select(x => new CategoryClass
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.CategoryID
                }).ToList();
            }
            return cs2;
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
            List<HeadingClass> cs2 = new List<HeadingClass>();
            using (var c = new Context())
            {
                cs2 = c.Headings.Select(x => new HeadingClass
                {
                    HeadingName = x.HeadingName,
                    HeadingCount = x.HeadingID
                }).ToList();
            }
            return cs2;

        }
    }
}