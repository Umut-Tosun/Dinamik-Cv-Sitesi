using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbl_iletisim> REPO = new GenericRepository<Tbl_iletisim>();
        public ActionResult Index()
        {
            var mesajlar = REPO.List();
            return View(mesajlar);
        }
        public ActionResult Okundu(int id)
        {
            var aranan = REPO.Find(x => x.ID == id);
            aranan.Okundu_mu = true;
            REPO.TUpdate(aranan);
            return RedirectToAction("Index");
        }
    }
}