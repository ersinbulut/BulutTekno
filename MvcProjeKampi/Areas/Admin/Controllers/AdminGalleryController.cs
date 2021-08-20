using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminGalleryController : Controller
    {
        IImageFileManager ifm = new IImageFileManager(new EfImageFileDal());
        // GET: Admin/AdminGallery
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}