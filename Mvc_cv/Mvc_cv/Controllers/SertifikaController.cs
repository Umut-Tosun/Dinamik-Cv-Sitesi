using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_Sertifikalarım> REPO = new GenericRepository<Tbl_Sertifikalarım>();
        public ActionResult Index()
        {
            var sertifikalarım = REPO.List();
            return View(sertifikalarım);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var aranan = REPO.Find(x => x.ID == id);
            return View(aranan);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(Tbl_Sertifikalarım P)
        {
            var aranan = REPO.Find(x => x.ID == P.ID);
            aranan.Tarih = P.Tarih;
            aranan.Aciklama = P.Aciklama;
            REPO.TUpdate(aranan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(Tbl_Sertifikalarım p)
        {
            REPO.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var aranan = REPO.Find(x => x.ID == id);
            REPO.TDelete(aranan);
            return RedirectToAction("Index");
        }

    }
}