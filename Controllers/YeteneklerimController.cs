using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
namespace MvcCv.Controllers
{
    [Authorize]
    public class YeteneklerimController : Controller
    {
        // GET: Yeteneklerim
        CvDbEntities db=new CvDbEntities();
        //YetenekRepository a=new YetenekRepository(); bunuda kullansam olur.
        GenericRepository<TblYeteneklerim> rep = new GenericRepository<TblYeteneklerim>();
        public ActionResult Index()
        {
            var yetenek = rep.List();
            return View(yetenek);
        }
        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYeteneklerim p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = rep.Find(x => x.ID == id);
            rep.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = rep.Find(x => x.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim p)
        {
            var yetenek = rep.Find(x => x.ID == p.ID);
            yetenek.Yetenek=p.Yetenek;
            yetenek.Oran=p.Oran;
            rep.TUpdate(yetenek);
            return RedirectToAction("Index");
        }
    }
}