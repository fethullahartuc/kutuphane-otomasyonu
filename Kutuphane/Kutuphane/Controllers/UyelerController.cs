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
    public class UyelerController : Controller
    {
        // GET: Uyeler
        KutuphaneContext context = new KutuphaneContext();
        UyelerDAL uyelerDal = new UyelerDAL();
        public ActionResult Index(string ara)
        {
            var model = uyelerDal.GetAll(context);

            if (ara != null)
            {
                model = uyelerDal.GetAll(context, x => x.AdiSoyadi.Contains(ara));

            }
            return View("Index",model); 
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Ekle(Uyeler entity)
        {
            if (ModelState.IsValid)
            {
                uyelerDal.InsertorUpdate(context,entity);
                uyelerDal.Save(context);
                return RedirectToAction("/Index");
            }
            
            return View();
        }

        public ActionResult Duzenle(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var model = uyelerDal.GetByFilter(context,x=>x.Id==id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Uyeler uyeler)
        {
            if (ModelState.IsValid)
            {
                uyelerDal.InsertorUpdate(context, uyeler);
                uyelerDal.Save(context);
                return RedirectToAction("/Index");
            }
            return View(uyeler);
        }
        public ActionResult Sil(int? id)
        {
            if(id==null)
            {
                return HttpNotFound();
            }
            uyelerDal.Delete(context, x => x.Id == id);
            uyelerDal.Save(context);
            return RedirectToAction("/Index");
        }
    }
}