using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        CvDbEntities db =new CvDbEntities();
        public ActionResult Index()
        {
            var deger=db.TblHakkimda.ToList();
            return View(deger);
        }
        public PartialViewResult Deneyim()
        {
            var deger =db.TblDeneyim.ToList();
            return PartialView(deger);
        }

        public PartialViewResult Egitim()
        {
            var egitims=db.TblEgitimim.ToList();
            return PartialView(egitims);
        }
        public PartialViewResult SosyalMedya()
        {
            var medyas = db.TblSosyalMedya.ToList();
            return PartialView(medyas);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneks = db.TblYeteneklerim.ToList();
            return PartialView(yeteneks);
        }
        public PartialViewResult Hobilerim()
        {
            var hobis = db.TblHobilerim.ToList();
            return PartialView(hobis);
        }
        public PartialViewResult dow()
        {
            return PartialView();
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikas = db.TblSertifikalarim.ToList();
            return PartialView(sertifikas);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}