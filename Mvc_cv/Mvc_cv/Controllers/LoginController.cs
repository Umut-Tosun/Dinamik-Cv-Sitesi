using Mvc_cv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_cv.Controllers
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
        public ActionResult Index(Tbl_Admin p)
        {
            DbcvEntities4 db = new DbcvEntities4();
            var bilgi = db.Tbl_Admin.FirstOrDefault(x => x.Kullanici_Adi == p.Kullanici_Adi && x.Sifre == p.Sifre);
            if (bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullanici_Adi,false);
                Session["Kullanici_Adi"] = bilgi.Kullanici_Adi.ToString();
                return RedirectToAction("Index","Hakkımda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}