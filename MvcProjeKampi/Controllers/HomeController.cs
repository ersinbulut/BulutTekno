using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager contentmanager = new ContentManager(new EfContentDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //[Route("Home/İletisim/")]
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        //[Route("Home/Anasayfa/")]
        public ActionResult HomePage()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult BlogDetails(int id)
        {
            var headingValue = contentmanager.GetByID(id);
            return View(headingValue);
        }
    }
}