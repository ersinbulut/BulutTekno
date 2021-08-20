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
        // GET: Admin/AdminTalent
        public ActionResult Index()
        {
            return View();
        }
    }
}