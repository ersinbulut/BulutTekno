using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminTestController : Controller
    {
        ToDoListManager tdlm = new ToDoListManager(new EfToDoListDal());
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
        
    }
}