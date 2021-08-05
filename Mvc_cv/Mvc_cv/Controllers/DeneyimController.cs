using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository dr = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = dr.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim P)
        {
            dr.TAdd(P);
            return  RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimlerim t = dr.Find(x=>x.ID==id);
            dr.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimlerim t = dr.Find(x => x.ID == id);
            ViewBag.x = t.Tarih;
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t = dr.Find(x => x.ID == p.ID);
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            t.Alt_Baslik = p.Alt_Baslik;
            t.Baslik = p.Baslik;
            dr.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}