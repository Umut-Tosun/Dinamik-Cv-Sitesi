using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class HakkımdaController : Controller
    {
        // GET: Hakkımda
        GenericRepository<Tbl_Hakkımda> REPO = new GenericRepository<Tbl_Hakkımda>();
        [HttpGet]
        public ActionResult Index()
        {
            var liste = REPO.List();
            return View(liste);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkımda p)
        {
            var t = REPO.Find(x => x.ID == 1);
            t.Ad = p.Ad; ;
            t.Soyad = p.Soyad;
            t.Telefon = p.Telefon;
            t.Mail = p.Mail;
            t.Aciklama = p.Aciklama;
            t.Adres = p.Adres;             
            t.Görsel = p.Görsel;
            REPO.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}