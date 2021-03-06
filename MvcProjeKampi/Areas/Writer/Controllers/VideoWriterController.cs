using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Writer.Controllers
{
    public class VideoWriterController : Controller
    {
        VideoManager vm = new VideoManager(new EfVideoDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        CommentManager commentmanager = new CommentManager(new EfCommentDal());
        Context c = new Context();
        // GET: Writer/BlogWriter
        public ActionResult Index(string p)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = vm.GetListByWriterID(writeridinfo);
            ViewBag.wid = writeridinfo;
            return View(values);
        }
        public PartialViewResult VideoListPartial(string p)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = vm.GetListByWriterID(writeridinfo);
            return PartialView(values);
        }

        public PartialViewResult NewVideoPartial()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            return PartialView();
        }

        public PartialViewResult YorumlarPartial(int id)
        {
            var yorum = commentmanager.GetListByVideo(id);
            return PartialView(yorum);
        }

        [HttpPost]
        public ActionResult NewVideo(Video p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.VideoDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.VideoStatus = true;
            vm.VideoAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteVideo(int id)
        {
            var deger = vm.GetByID(id);
            vm.VideoDelete(deger);
            return RedirectToAction("Index");
        }

    }
}