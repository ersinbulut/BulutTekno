using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class BlogController : Controller
    {
        //HeadingManager hm = new HeadingManager(new EfHeadingDal());
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        ContentManager contentmanager = new ContentManager(new EfContentDal());
        CommentManager commentmanager = new CommentManager(new EfCommentDal());
      
        // GET: Blog
        public ActionResult Index()
        {
            var blogvalues = blogmanager.GetList();
            return View(blogvalues);
        }

        public ActionResult BlogDetails(int id)
        {
            ViewBag.dgr = id;
            var blogValue = blogmanager.GetListByBlogID(id);
            return View(blogValue);
        }
        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.WriterID = 1;
            comment.ParentID = 1;
            comment.ImageUrl = "https://image.flaticon.com/icons/png/512/146/146031.png";
            commentmanager.CommentAdd(comment);
            TempData["Mesaj"] = "Yorumunuz Gönderildi";
            return RedirectToAction("BlogDetails/" + comment.BlogID);
        }
        public PartialViewResult Yorumlar(int id)
        {
            var yorum = commentmanager.GetByID1(id);
            return PartialView(yorum);
        }
        public PartialViewResult YorumlarPartial(int id)
        {
            var yorum = commentmanager.GetListByBlog(id);
            return PartialView(yorum);
        }

        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }

    }
}