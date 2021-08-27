using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminTestController : Controller
    {
        ToDoListManager tdlm = new ToDoListManager(new EfToDoListDal());
        Context c = new Context();
        WriterManager wm = new WriterManager(new EfWriterDal());
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Admin/AdminTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult ToDoList()
        {
            var todolistvalues = tdlm.GetList();/*.OrderByDescending(x=>x.ToDoID).FirstOrDefault()*/
            return View(todolistvalues);
        }

        public ActionResult SweetAlert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ToDoListAdd(ToDoList toDoList)
        {
            toDoList.ToDoDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            //toDoList.ToDoStatus = true;
            toDoList.ImageUrl = "a.jpg";
            tdlm.ToDoListAdd(toDoList);
            //return RedirectToAction("ToDoList");
            return RedirectToAction("ToDoList", "Admin/AdminTest");
        }
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult AdminProfile(int id = 0)
        {
            string p = (string)Session["AdminUserName"];
            id = c.Admins.Where(x => x.AdminUserName == p).Select(y => y.AdminID).FirstOrDefault();
            var adminvalue = adminManager.GetByID(id);

            return View(adminvalue);
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adminManager.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(AdminUser p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.AdminImage = "/Image/" + dosyaadi + uzanti;
            }
            adminManager.AdminUpdate(p);
            return RedirectToAction("AdminProfile", "AdminTest");

        }


    }
}