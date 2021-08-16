using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        IImageFileManager ifm = new IImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}