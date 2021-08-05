using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
namespace Mvc_cv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Tbl_Admin> REPO = new GenericRepository<Tbl_Admin>();
        public ActionResult Index()
        {
            var liste = REPO.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin P)
        {
            REPO.TAdd(P);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            Tbl_Admin t = REPO.Find(x => x.ID == id);
            REPO.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            Tbl_Admin t = REPO.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGetir(Tbl_Admin p)
        {
            Tbl_Admin t = REPO.Find(x => x.ID == p.ID);
            t.Kullanici_Adi = p.Kullanici_Adi;
            t.Sifre = p.Sifre;
            REPO.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}