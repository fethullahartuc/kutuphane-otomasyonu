using Kutuphane_Otomasyonu.DAL;
using Kutuphane_Otomasyonu.Model;
using Kutuphane_Otomasyonu.Model.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KitapTurleriController : Controller
    {
        // GET: KitapTurleri
        KutuphaneContext  context = new KutuphaneContext();
        KitapTurleriDAL kitapTurleriDal = new KitapTurleriDAL();

        public ActionResult Index(string ara)
        {
            var model = kitapTurleriDal.GetAll(context);
            
            if(ara!=null)
            {
                model = kitapTurleriDal.GetAll(context,x=>x.KitapTuru.Contains(ara));
            }
            return View("Index",model); // kontrol edilecek
        }
        public ActionResult Ekle()
        { 
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(KitapTurleri kitapTurleri)
        {
            if(ModelState.IsValid)
            {
                kitapTurleriDal.InsertorUpdate(context, kitapTurleri);
                kitapTurleriDal.Save(context);
                return RedirectToAction("/Index");
            }
            return View(kitapTurleri);
            
        }

        public ActionResult Duzenle(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var model = kitapTurleriDal.GetById(context,id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)
            {
                kitapTurleriDal.InsertorUpdate(context, kitapTurleri);
                kitapTurleriDal.Save(context);
                return RedirectToAction("/Index");
            }
            return View(kitapTurleri);

        }
        public ActionResult Sil(int? id)
        {
            kitapTurleriDal.Delete(context,x=>x.Id==id);
            kitapTurleriDal.Save(context);
            return RedirectToAction("/Index");
        }
    }
}