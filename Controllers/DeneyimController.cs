using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo=new DeneyimRepository();
        public ActionResult Index()
        {
            var deger= repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TblDeneyim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TblDeneyim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TblDeneyim p)
        {
            TblDeneyim t = repo.Find(x => x.ID == p.ID);
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Aciklama=p.Aciklama;
            t.Tarih=p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}