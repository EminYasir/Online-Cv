using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [Authorize]
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo =new GenericRepository<TblSosyalMedya> ();   
        public ActionResult Index()
        {
            var deger = repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SayfaGetir(int id)
        {
            var sosyal = repo.Find(x => x.ID == id);
            return View(sosyal);
        }
        [HttpPost]
        public ActionResult SayfaGetir(TblSosyalMedya sm)
        {
            var sosyal = repo.Find(x => x.ID == sm.ID);
            sosyal.Link=sm.Link;
            sosyal.icon = sm.icon;
            sosyal.Ad=sm.Ad;
            repo.TUpdate(sosyal);
            return RedirectToAction ("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            var sosyal=repo.Find(x => x.ID == id);
            repo.TDelete(sosyal);
            return RedirectToAction ("Index");
        }
    }
}