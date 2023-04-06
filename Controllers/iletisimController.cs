using MvcCv.Models.Entity;
using MvcCv.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        GenericRepository<Tbliletisim> repo=new GenericRepository<Tbliletisim>();
        public ActionResult Index()
        {
            var deger=repo.List();
            return View(deger);
        }
        public ActionResult iletisimSil(int id)
        {
            var deger=repo.Find(x=> x.ID==id);
            repo.TDelete(deger);
            return RedirectToAction("Index");
        }
    }
}