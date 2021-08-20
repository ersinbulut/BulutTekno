using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Admin/AdminContent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);
            //var values = c.Contents.ToList();
            return View(values.ToList());
        }

        //içerikleri heading e göre getir
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}