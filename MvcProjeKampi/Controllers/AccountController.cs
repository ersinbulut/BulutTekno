﻿using MvcProjeKampi.Helpers;
using MvcProjeKampi.Identity;
using MvcProjeKampi.Models;
using MvcProjeKampi.Services.Senders;
using MvcProjeKampi.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrate;

namespace MvcProjeKampi.Controllers
{
    public class AccountController : Controller
    {
        Context db = new Context();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        private IdentityDataContext identityDb = new IdentityDataContext();

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(identityDb);
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(identityDb);
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Index()
        {
            //var username = User.Identity.Name;
            //var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrderModel
            //{
            //    Id = i.Id,
            //    OrderNumber = i.OrderNumber,
            //    OrderDate = i.OrderDate,
            //    OrderState = i.OrderState,
            //    Total = i.Total
            //}).OrderByDescending(i => i.OrderDate).ToList();//azalan olarak sıraladık yani en son verilen sipariş en başa gelir.
            return View();
            //orders tablosundaki bilgileri userOrderModel tablosunun içerisine paketledik
        }


        public ActionResult Details(int id)
        {
            //var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            //{
            //    OrderId = i.Id,
            //    OrderNumber = i.OrderNumber,
            //    Total = i.Total,
            //    OrderDate = i.OrderDate,
            //    OrderState = i.OrderState,
            //    AdresBasligi = i.Addres.AdresBasligi,
            //    Adres = i.Addres.Adres,
            //    Il = i.Addres.Il,
            //    Ilce = i.Addres.Ilce,
            //    Mahalle = i.Addres.Mahalle,
            //    PostaKodu = i.Addres.PostaKodu,
            //    UserAddressID = i.UserAddressID,
            //    /*kart bilgileri*/
            //    CartNumber = i.Pay.CartNumber,
            //    SecurityNumber = i.Pay.SecurityNumber,
            //    CartHasName = i.Pay.CartHasName,
            //    ExpYear = i.Pay.ExpYear,
            //    ExpMonth = i.Pay.ExpMonth,
            //    /**/
            //    OrderLines = i.OrderLines.Select(x => new OrderLineModel()
            //    {
            //        ProductId = x.ProductId,
            //        Image = x.Product.Image,
            //        ProductName = x.Product.Name,
            //        Quantity = x.Quantity,
            //        Price = x.Price
            //    }).ToList()
            //}).FirstOrDefault();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.DateOfBirth = model.DateOfBirth;
                user.Gender = model.Gender;
                user.ActivationCode = StringHelpers.GetCode();

                var result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    string SiteUrl = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host +
                        (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                    //mail gönder
                    var emailService = new EmailService();
                    var body = $"Merhaba <b>{user.Name}  {user.Surname}</b> <br/> Hesabınızı aktif etmek için aşağıdaki linke tıklayınız" +
                        $"<br/><a href='{SiteUrl}/Account/Activation?code={user.ActivationCode}'>Aktivasyon Linki</a>";
                    await emailService.SendAsync(new IdentityMessage() { Body = body, Subject = "Buluttekno'ya Hoşgeldiniz" }, user.Email);

                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası...");
                }
            }
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);//modelden alınan kullanıcıadı ve şifreye göre kullanıcı arar
                if (user != null)//kullanıcı sistemde var ise
                {
                    var autManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;//sisteme beni dahil et
                    autManager.SignIn(authProperties, identityclaims);
                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("HomePage", "Home");
                    //return RedirectToAction("MyContent", "WriterPanelContent", new { Area = "Writer" });
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok..");
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            //var aut = Request.IsAuthenticated == false;
            //aut.ToString();
            return RedirectToAction("HomePage", "Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult UserProfile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new ProfilePasswordViewModel()
            {
                UserProfileViewModel = new UserProfileViewModel()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    /**/
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    /**/
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    Username = user.UserName
                }
            };
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> UpdateProfile(ProfilePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }
            var userManager = UserManager;

            var user = await UserManager.FindByIdAsync(model.UserProfileViewModel.Id);

            user.Name = model.UserProfileViewModel.Name;
            user.Surname = model.UserProfileViewModel.Surname;
            user.PhoneNumber = model.UserProfileViewModel.PhoneNumber;
            user.Email = model.UserProfileViewModel.Email;
            /**/
            user.DateOfBirth = model.UserProfileViewModel.DateOfBirth;
            user.Gender = model.UserProfileViewModel.Gender;

            if (Request.Files != null && Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                //if (file.ContentLength > 0)
                //{
                //    var folder = Server.MapPath("~/Content/Images");
                //    var fileName = Guid.NewGuid() + ".jpg";
                //    file.SaveAs(Path.Combine(folder, fileName));

                //    var filePath = "Content/Images/" + fileName;
                //    user.Image = filePath;
                //    user.Image = model.UserProfileViewModel.Image;
                //}
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    user.Image = "/Image/" + dosyaadi + uzanti;
                }
            }
            /**/

            await userManager.UpdateAsync(user);
            TempData["mesaj"] = "Bilgileriniz kaydedildi";
            return RedirectToAction("UserProfile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> ChangePassword(ProfilePasswordViewModel model)
        {
            var userManager = UserManager;
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new ProfilePasswordViewModel()
            {
                UserProfileViewModel = new UserProfileViewModel()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Surname = user.Surname,
                    Username = user.UserName
                }
            };
            model.UserProfileViewModel = data.UserProfileViewModel;
            if (!ModelState.IsValid)
            {
                return View("UserProfile", model);
            }

            var result = await userManager.ChangePasswordAsync(HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId(),
                model.changePasswordView.OldPassword,
                model.changePasswordView.NewPassword);
            if (result.Succeeded)
            {//mail gönder
                var emailService = new EmailService();
                var body = $"Merhaba <b>{user.Name}  {user.Surname}</b> <br/> <p>Hesabınızın şifresi güncellenmiştir.</p>";
                await emailService.SendAsync(new IdentityMessage() { Body = body, Subject = "Şifre Değişikliği" }, user.Email);
                return RedirectToAction("LogOut", "Account");
            }
            return View("UserProfile", model);

        }
        public ActionResult UserPassword()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Activation(string code)
        {
            try
            {
                var userStore = UserManager;
                var user = userStore.Users.FirstOrDefault(x => x.ActivationCode == code);

                if (user != null)
                {
                    if (user.EmailConfirmed)
                    {
                        ViewBag.Message = $"<span class='alert alert-success'>Bu hesap daha önce aktive edilmiştir</span>";
                    }
                    else
                    {
                        user.EmailConfirmed = true;

                        UserManager.Update(user);
                        ViewBag.Message = $"<span class='alert alert-success'>Aktivasyon işlemi başarılı</span>";
                    }
                }
                else
                {
                    ViewBag.Message = $"<span class='alert alert-danger'>Aktivasyon başarısız</span>";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"<span class='alert alert-danger'>Aktivasyon işleminde bir hata oluştu</span>" + ex.Message;
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RecoverPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> RecoverPassword(RecoverPasswordViewModel model)
        {
            try
            {
                var userStore = new UserStore<ApplicationUser>(identityDb);
                var userManager = UserManager;
                var user = await userStore.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    //ModelState.AddModelError(string.Empty, $"{model.Email} mail adresine kayıtlı bir üyeliğe erişilemedi");
                    TempData["mesaj"] = $"{model.Email} mail adresine kayıtlı bir üyeliğe erişilemedi";
                    return View(model);
                }

                var newPassword = StringHelpers.GetCode().Substring(0, 6);//yeni şifre
                await userStore.SetPasswordHashAsync(user, userManager.PasswordHasher.HashPassword(newPassword));
                userStore.Context.SaveChanges();
                TempData["mesaj1"] = "Yeni şifreniz mail adresinize gönderildi.";
                //mail gönder
                var emailService = new EmailService();
                var body = $"Merhaba <b>{user.Name}  {user.Surname}</b> <br/>Hesabınızın parolası sıfırlanmıştır" +
                    $"<br/>Yeni parolanız: <b>{newPassword}</b><br/><p>Yukarıdaki parolayı kullanarak sisteminize giriş yapabilirsiniz.</p>";
                emailService.Send(new IdentityMessage() { Body = body, Subject = $"{user.UserName} Şifre Kurtarma" }, user.Email);


            }
            catch (Exception ex)
            {
                ViewBag.Message = $"<span class='alert alert-danger'>Sıfırlama işleminde bir hata oluştu</span>" + ex.Message;
            }

            return View();
        }
    }
}