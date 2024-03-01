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
    public class YazarlarController : Controller
    {
        // GET: Yazarlar
        KutuphaneContext context = new KutuphaneContext();
        YazarlarDAL yazarlarDAL = new YazarlarDAL();
        public ActionResult Index(string ara)
        {
            var model = yazarlarDAL.GetAll(context);

            if (ara != null)
            {
                model = yazarlarDAL.GetAll(context, x => x.YazarAdi.Contains(ara));
            }
            return View("Index", model); // kontrol edilecek
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                yazarlarDAL.InsertorUpdate(context, yazarlar);
                yazarlarDAL.Save(context);
                return RedirectToAction("/Index");
            }
            return View(yazarlar);

        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = yazarlarDAL.GetById(context, id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Yazarlar yazarlar)
        {
            if (ModelState.IsValid)
            {
                yazarlarDAL.InsertorUpdate(context, yazarlar);
                yazarlarDAL.Save(context);
                return RedirectToAction("/Index");
            }
            return View(yazarlar);

        }
        public ActionResult Sil(int? id)
        {
            yazarlarDAL.Delete(context, x => x.Id == id);
            yazarlarDAL.Save(context);
            return RedirectToAction("/Index");
        }
    }
}