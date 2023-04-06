using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            CvDbEntities dbEntities = new CvDbEntities();
            var bilgi = dbEntities.TblAdmin.FirstOrDefault(x => x.Kullaniciadi == admin.Kullaniciadi && x.Sifre == admin.Sifre);
            if (bilgi !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullaniciadi, false);
                Session["KullaniciAdi"] = bilgi.Kullaniciadi.ToString();
                return RedirectToAction("Index","Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}