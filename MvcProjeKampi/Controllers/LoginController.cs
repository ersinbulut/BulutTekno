using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            //Context c = new Context();
           // var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
            var adminuserinfo = adm.GetList().FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);


            if (adminuserinfo != null)
            {
                //if (new LoginCheck().IsLoginSuccess(p))
                //{
                    FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                    Session["AdminUserName"] = adminuserinfo.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                //}
              
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            // var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
            //var writeruserinfo = wm.GetList().FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);

            if (writeruserinfo != null)
            {
                //if (new LoginCheck().IsLoginSuccess(p))
                //{
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                TempData["dogru"] = "bilgiler dogru";
                return RedirectToAction("MyContent", "WriterPanelContent");
                //}

            }
            else
            {
                TempData["yanlis"] = "bilgiler yanlış";
                return RedirectToAction("WriterLogin");
            }
        }

        [HttpGet]
        public ActionResult RegisterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterLogin(Writer p)
        {
            wm.WriterAdd(p);
            TempData["mesaj"] = "Kayıt işlemi başarılı";
            return View();
            ////Context c = new Context();
            //// var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == p.AdminUserName && x.AdminUserPassword == p.AdminUserPassword);
            ////var writeruserinfo = wm.GetList().FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            //var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);

            //if (writeruserinfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
            //    Session["WriterMail"] = writeruserinfo.WriterMail;
            //    wm.WriterAdd(writeruserinfo);
            //    return RedirectToAction("WriterLogin", "Login");
            //}
            //else
            //{
            //    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası...");
            //    return View();
            //}
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Register(Admin adminModel)
        //{
        //    Context c = new Context();

        //    var crypto = new SimpleCrypto.PBKDF2();
        //    var encrypedPassword = crypto.Compute(adminModel.AdminUserPassword);

        //    var User = new Admin();

        //    int result = 0;

        //    if (adminModel.AdminID == result)
        //    {
        //        User.AdminUserName = adminModel.AdminUserName;
        //        User.AdminUserPassword = encrypedPassword;
        //        User.Salt = crypto.Salt;
        //        c.Admins.Add(User);
        //        c.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
    }
}