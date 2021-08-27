using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context db = new Context();
        // GET: Admin/AdminCategory
        //[Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            //cm.CategoryAddBL(cat);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(cat);
            if (result.IsValid)//sonuç geçerliyse
            {
                cm.CategoryAdd(cat);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //[HttpGet]
        //public ActionResult SubCategoryAdd()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SubCategoryAdd(Category cat)
        //{
        //    //cm.CategoryAddBL(cat);
        //    CategoryValidator categoryValidator = new CategoryValidator();
        //    ValidationResult result = categoryValidator.Validate(cat);
        //    if (result.IsValid)//sonuç geçerliyse
        //    {
        //        cm.CategoryAdd(cat);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        // GET: Category/Create
        public ActionResult SubCategoryAdd()
        {
            ViewBag.ParentId = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult SubCategoryAdd([Bind(Include = "CategoryID,CategoryName,CategoryDesctription,ParentID")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public PartialViewResult _CategoryList()
        {
            var kategoriler = db.Categories.Select(x => new CategoryModel()
            //var kategoriler = db.Categories.Select(x => new Category()
            {
                CategoryID = x.CategoryID,
                ParentID = x.ParentID,
                CategoryName = x.CategoryName,
                Count = x.Blogs.Count()
            }
            ).ToList();
            return PartialView(kategoriler);

            //List<Category> all = new List<Category>();
            //all = db.Categories.OrderBy(a => a.ParentId).ToList();
            //return PartialView(all);
        }


        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);//parametre olarak gönderilen id ye göre getir
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {//böylece ıd değişkeninden gelen parametre değerine göre ilgili satırın kayıtlarını categoryvalue
            //isimli değişkene atadık
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

    }
}