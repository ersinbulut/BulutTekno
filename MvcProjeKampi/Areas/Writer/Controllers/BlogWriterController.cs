using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class BlogWriterController : Controller
    {
        // GET: Writer/BlogWriter
        public ActionResult Index()
        {
            return View();
        }
    }
}