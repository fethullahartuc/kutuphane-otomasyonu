using Kutuphane_Otomasyonu.DAL;
using Kutuphane_Otomasyonu.Mapping;
using Kutuphane_Otomasyonu.Model;
using Kutuphane_Otomasyonu.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class EmanetKitaplarController : Controller
    {
        // GET: EmanetKitaplar
        KutuphaneContext context=new KutuphaneContext();
        EmanetKitaplarDAL emanetKitaplarDal = new EmanetKitaplarDAL();
        public ActionResult Index()
        {
            var model = emanetKitaplarDal.GetAll(context,x=>x.KitapIadeTarihi==null,"Kitaplar","Uyeler");
            return View(model);
        }

        public ActionResult EmanetKitapVer()
        {
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]

        public ActionResult EmanetKitapVer(EmanetKitaplar emanetkitaplar)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
                ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
                return View();
            }
            emanetKitaplarDal.InsertorUpdate(context, emanetkitaplar);
            emanetKitaplarDal.Save(context);
            return RedirectToAction("/Index");    
         
        }
         public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
            var model = emanetKitaplarDal.GetByFilter(context, x => x.Id == id, "Uyeler", "Kitaplar");
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]

        public ActionResult Duzenle(EmanetKitaplar emanetkitaplar)
        {
            if (ModelState.IsValid)
            {
                emanetKitaplarDal.InsertorUpdate(context, emanetkitaplar);
                emanetKitaplarDal.Save(context);
                return RedirectToAction("/Index");
            }
            ViewBag.UyeListe = new SelectList(context.Uyeler, "Id", "AdiSoyadi");
            ViewBag.KitapListe = new SelectList(context.Kitaplar, "Id", "KitapAdi");
            return View("/Index");
        }

        public ActionResult Sil(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            emanetKitaplarDal.Delete(context,x=>x.Id==id);
            emanetKitaplarDal.Save(context);
            return RedirectToAction("/Index");
        }

        public ActionResult IadeAl(int? id)
        {
            var model = emanetKitaplarDal.GetByFilter(context,x=>x.Id==id);
            model.KitapIadeTarihi=DateTime.Now;
            emanetKitaplarDal.Save(context);
            return RedirectToAction("/Index");
        }

        public ActionResult IadeEdilenler()
        {
            var model = emanetKitaplarDal.GetAll(context, x => x.KitapIadeTarihi != null, "Kitaplar", "Uyeler");
            return View(model);
        }
    }
}