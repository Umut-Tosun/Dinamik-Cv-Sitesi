using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Egitimlerim> REPO = new GenericRepository<Tbl_Egitimlerim>();
        public ActionResult Index()
        {
            var egitimler = REPO.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim P)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            REPO.TAdd(P);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = REPO.Find(x=>x.ID==id);
            REPO.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var egitim = REPO.Find(x => x.ID == id);
            ViewBag.x = egitim.Tarih;
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(Tbl_Egitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            var aranan = REPO.Find(x => x.ID == p.ID);
            aranan.Baslik = p.Baslik;
            aranan.Alt_Baslik = p.Alt_Baslik;
            aranan.Alt_Baslik2 = p.Alt_Baslik2;
            aranan.Gno = p.Gno;
            aranan.Tarih = p.Tarih;
            REPO.TUpdate(aranan);
            return RedirectToAction("Index");
        }
    }
}