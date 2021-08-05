using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_cv.Models.Entity;
namespace Mvc_cv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbcvEntities4 db = new DbcvEntities4();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkımda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var degerler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var degerler = db.Tbl_Sosyalmedya.Where(x=>x.Durum==true).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Egitimlerim()
        {
            var degerler = db.Tbl_Egitimlerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var degerler = db.Tbl_Yeteneklerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Hobilerim()
        {
            var degerler = db.Tbl_Hobilerim.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Sertifikalarım()
        {
            var degerler = db.Tbl_Sertifikalarım.ToList();
            return PartialView(degerler);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }     
        [HttpPost]
        public PartialViewResult iletisim(Tbl_iletisim p)
        {
            p.Tarih =DateTime.Now.ToShortDateString();
            db.Tbl_iletisim.Add(p);
            db.SaveChanges();
            ViewBag.mesaj = "Mesajınız Gönderildi";
            return PartialView();
        }
    }
}