using Mvc_cv.Models.Entity;
using Mvc_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_cv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Tbl_Hobilerim> REPO = new GenericRepository<Tbl_Hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var liste = REPO.List();
            return View(liste);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            var t = REPO.Find(x=>x.ID==1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            REPO.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}