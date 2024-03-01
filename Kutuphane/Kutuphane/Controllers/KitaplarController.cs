using Kutuphane_Otomasyonu.DAL;
using Kutuphane_Otomasyonu.Mapping;
using Kutuphane_Otomasyonu.Model;
using Kutuphane_Otomasyonu.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Kutuphane.Controllers
{
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL kitaplarDal = new KitaplarDAL();
        public ActionResult Index(string ara)
        {
            var model = kitaplarDal.GetAll(context, null, "KitapTurleri", "Yazarlar");
            if (ara != null)
            {
                model = kitaplarDal.GetAll(context, x => x.KitapAdi.Contains(ara));
            }
            return View("Index", model);
        }
        public ActionResult Ekle()
        {
            ViewBag.KitapListe = new SelectList(context.KitapTurleri, "Id","KitapTuru");
            ViewBag.YazarListe = new SelectList(context.Yazarlar, "Id","YazarAdi");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KitapListe = new SelectList(context.KitapTurleri, "Id", "KitapTuru");
                ViewBag.YazarListe = new SelectList(context.Yazarlar, "Id", "YazarAdi");
                return View();
            }
            kitaplarDal.InsertorUpdate(context,entity);
            kitaplarDal.Save(context);
            return RedirectToAction("/Index");
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = kitaplarDal.GetByFilter(context, x => x.Id == id, "KitapTurleri", "Yazarlar");
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.KitapListe = new SelectList(context.KitapTurleri, "Id", "KitapTuru");
            ViewBag.YazarListe = new SelectList(context.Yazarlar, "Id", "YazarAdi");
            return View(model);   

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KitapListe = new SelectList(context.KitapTurleri, "Id", "KitapTuru");
                ViewBag.YazarListe = new SelectList(context.Yazarlar, "Id", "YazarAdi");
                return View();
            }
            kitaplarDal.InsertorUpdate(context, entity);
            kitaplarDal.Save(context);
            return RedirectToAction("/Index");
        }
        public ActionResult Detay(int? id)
        {
            var model = kitaplarDal.GetByFilter(context,x=> x.Id == id,"KitapTurleri","Yazarlar");
            return View(model);
        }

        public ActionResult Sil(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            kitaplarDal.Delete(context,x => x.Id==id);
            kitaplarDal.Save(context);
            return RedirectToAction("/Index");
        }
    }
}