using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        ContactManager mesajmanager = new ContactManager(new EfContactDal());
        CommentManager commentmanager = new CommentManager(new EfCommentDal());
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
        [HttpPost]
        public ActionResult SendMessage(Contact message)
        {
            message.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesajmanager.ContactAdd(message);
            TempData["Dogru"] = "mesaj gönderildi";
            return RedirectToAction("Contact");
        }

        public ActionResult Test()
        {
            return View();
        }
        //[AllowAnonymous]
        //[Route("Home/Anasayfa/")]
        public ActionResult HomePage()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult BlogDetails(int id)
        {
            ViewBag.dgr = id;
            var headingValue = contentmanager.GetListByHeadingID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.WriterID = 1;
            comment.ParentID = 1;
            commentmanager.CommentAdd(comment);
            TempData["Mesaj"] = "Yorumunuz Gönderildi";
            return RedirectToAction("BlogDetails/" + comment.ContentID);
        }
        public PartialViewResult Yorumlar(int id)
        {
            var yorum = commentmanager.GetByID(id);
            return PartialView(yorum);
        }

        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }

        public ActionResult Blog()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult Video()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult News()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpPost]
        public ActionResult Search(string p)
        {
            var values = hm.GetList(p);
            //var values = c.Contents.ToList();
            return View(values.ToList());
        }
    }
}