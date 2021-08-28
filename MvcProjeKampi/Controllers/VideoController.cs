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
    public class VideoController : Controller
    {
       // HeadingManager hm = new HeadingManager(new EfHeadingDal());
        VideoManager vm = new VideoManager(new EfVideoDal());
        CommentManager commentmanager = new CommentManager(new EfCommentDal());
        // GET: Video
        public ActionResult Index()
        {
            var headingvalues = vm.GetList();
            return View(headingvalues);
        }

        public ActionResult VideoDetails(int id)
        {
            ViewBag.dgr = id;
            var videoValue = vm.GetVideoList(id);
            return View(videoValue);
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
            return RedirectToAction("VideoDetails/" + comment.VideoID);
        }
        public PartialViewResult Yorumlar(int id)
        {
            var yorum = commentmanager.GetByID2(id);
            return PartialView(yorum);
        }
        public PartialViewResult YorumlarPartial(int id)
        {
            var yorum = commentmanager.GetListByVideo(id);
            return PartialView(yorum);
        }

        public JavaScriptResult MesajGoster()
        {
            string msg = "<script> alert('Yorumunuz yöneticinin onayına gönderildi en kısa zamanda yayınlanacak..'); </script>";
            return JavaScript(msg);
        }

    }
}