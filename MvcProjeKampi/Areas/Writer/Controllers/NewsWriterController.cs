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
    public class NewsWriterController : Controller
    {
        NewsManager nm = new NewsManager(new EfNewsDal());
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
            var values = nm.GetListByWriterID(writeridinfo);
            ViewBag.wid = writeridinfo;
            return View(values);
        }
        public PartialViewResult NewsListPartial(string p)
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
            var values = nm.GetListByWriterID(writeridinfo);
            return PartialView(values);
        }

        public PartialViewResult NewNewsPartial()
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
            var yorum = commentmanager.GetListByNews(id);
            return PartialView(yorum);
        }

        [HttpPost]
        public ActionResult NewNews(News p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.NewsDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.NewsStatus = true;
            nm.NewsAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteNews(int id)
        {
            var deger = nm.GetByID(id);
            nm.NewsDelete(deger);
            return RedirectToAction("Index");
        }
        
    }
}