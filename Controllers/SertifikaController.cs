using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();
        CvDbEntities entities = new CvDbEntities();
        public ActionResult Index()
        {
            var deger=repo.List();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SertifikaEkle()//bu ekleme olacak sayfa yönlendirme
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifikalarim p)// buda ekleme sayfasında ki post methodunun çalışması içim
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var deger = repo.Find(x => x.ID == id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var deger=repo.Find(x => x.ID == id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim s)
        {
            if (!ModelState.IsValid)
            {
                return View("SertifikaGetir");
            }
            var deger = repo.Find(x => x.ID == s.ID);
            deger.Tarih=s.Tarih;
            deger.Aciklama=s.Aciklama;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}