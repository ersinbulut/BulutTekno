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
    public class BlogWriterController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
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
            var values = bm.GetListByWriterID(writeridinfo);
            ViewBag.wid = writeridinfo;
            return View(values);
        }
        public PartialViewResult BlogListPartial(string p)
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
            var values = bm.GetListByWriterID(writeridinfo);
            return PartialView(values);
        }

        public PartialViewResult NewBlogPartial()
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
            var yorum = commentmanager.GetListByBlog(id);
            return PartialView(yorum);
        }

        //[HttpGet]
        //public ActionResult NewBlog()
        //{


        //    List<SelectListItem> valuecategory = (from x in cm.GetList()
        //                                          select new SelectListItem
        //                                          {
        //                                              Text = x.CategoryName,
        //                                              Value = x.CategoryID.ToString()
        //                                          }).ToList();
        //    ViewBag.vlc = valuecategory;
        //    return View();
        //}
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            p.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.BlogStatus = true;
            bm.BlogAdd(p);
            return RedirectToAction("Index");
        }


    }
}