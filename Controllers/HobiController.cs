using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo =new GenericRepository<TblHobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobis = repo.List();
            return View(hobis);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim h)
        {
            var deger=repo.Find(x => x.ID == 1);
            deger.Aciklama1 = h.Aciklama1;
            deger.Aciklama2 = h.Aciklama2;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}