using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<Tbl_Sosyalmedya> REPO = new GenericRepository<Tbl_Sosyalmedya>();
        public ActionResult Index()
        {
            var veriler = REPO.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SosyalMedyaEkle(Tbl_Sosyalmedya p)
        {
            REPO.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGetir(int id)
        {
            var hesap = REPO.Find(x=>x.ID==id);
            return View(hesap);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGetir(Tbl_Sosyalmedya p)
        {
            var hesap = REPO.Find(x => x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.icon = p.icon;
            REPO.TUpdate(hesap);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            var hesap = REPO.Find(x => x.ID == id);
            if (hesap.Durum==true)
            {
                hesap.Durum = false;
            }
            else
            {
                hesap.Durum = true;
            }
            REPO.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}