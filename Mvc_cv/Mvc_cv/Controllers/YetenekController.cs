using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
namespace Mvc_cv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        GenericRepository<Tbl_Yeteneklerim> REPO = new GenericRepository<Tbl_Yeteneklerim>();
        public ActionResult Index()
        {
            var yetenekler = REPO.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_Yeteneklerim P)
        {
            REPO.TAdd(P);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var aranan = REPO.Find(x => x.ID == id);
            REPO.TDelete(aranan);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGetir(int id)
        {
            var aranan = REPO.Find(x => x.ID == id);
            return View(aranan);
        }
        [HttpPost]
        public ActionResult YetenekGetir(Tbl_Yeteneklerim p)
        {
            var aranan = REPO.Find(x => x.ID == p.ID);
            aranan.Yetenek = p.Yetenek;
            aranan.Oran = p.Oran;
            REPO.TUpdate(aranan);
            return RedirectToAction("Index");
        }

    }
}