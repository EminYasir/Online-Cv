using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{

    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        
        [HttpGet]
        public ActionResult Index()
        {
            var hak = repo.List();
            return View(hak);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda h)
        {
            var deger = repo.Find(x => x.ID == 1);
            deger.Adres = h.Adres;
            deger.Ad = h.Ad;
            deger.Resim = h.Resim;
            deger.Aciklama = h.Aciklama;
            deger.Mail = h.Mail;
            deger.Soyad = h.Soyad;
            deger.Telefon = h.Telefon;
            repo.TUpdate(deger);
            return RedirectToAction("Index");
        }
    }
}