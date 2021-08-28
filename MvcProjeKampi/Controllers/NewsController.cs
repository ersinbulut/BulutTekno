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
    public class NewsController : Controller
    {
        NewsManager nw = new NewsManager(new EfNewsDal());
        CommentManager commentmanager = new CommentManager(new EfCommentDal());
        // GET: News
        public ActionResult Index()
        {
            var newsvalues = nw.GetList();
            return View(newsvalues);
        }

        public ActionResult NewsDetails(int id)
        {
            ViewBag.dgr = id;
            var newsValue = nw.GetNewsList(id);
            return View(newsValue);
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
            return RedirectToAction("NewsDetails/" + comment.NewsID);
        }
        public PartialViewResult Yorumlar(int id)
        {
            var yorum = commentmanager.GetByID3(id);
            return PartialView(yorum);
        }
        public PartialViewResult YorumlarPartial(int id)
        {
            var yorum = commentmanager.GetListByNews(id);
            return PartialView(yorum);
        }

        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }

    }
}