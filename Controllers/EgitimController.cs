using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimim> rep = new GenericRepository<TblEgitimim>();
        
        public ActionResult Index()
        {
            var egitim = rep.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var  egitim=rep.Find(x =>x.ID == id);
            rep.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = rep.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimim e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = rep.Find(x => x.ID == e.ID);
            egitim.Tarih=e.Tarih;
            egitim.AltBaslik1 = e.AltBaslik1;
            egitim.AltBaslik2 = e.AltBaslik2;
            egitim.Baslik=e.Baslik;
            egitim.GNO=e.GNO;
            rep.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}