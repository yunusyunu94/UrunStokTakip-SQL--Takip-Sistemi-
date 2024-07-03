using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    [Authorize(Roles = "A")]
    public class KategoriController : Controller
    {
        // GET: Kategori

        Takip_SistemiEntities db = new Takip_SistemiEntities();

        //[Authorize(Roles = "A")]
        public ActionResult Index()
        {
            return View(db.Kategori.Where(x => x.Durum == true).ToList());
        }

        //[Authorize(Roles = "A")]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        //[Authorize (Roles = "A")]
        public ActionResult Ekle(Kategori Data)
        {
            db.Kategori.Add(Data);
            Data.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "A")]
        public ActionResult Guncelle(int id)
        {
            var guncelle = db.Kategori.Where(x => x.Id == id).FirstOrDefault();


            return View(guncelle);
        }

        [HttpPost]
        //[Authorize(Roles = "A")]
        public ActionResult Guncelle(Kategori data)
        {
            var edit = db.Kategori.Find(data.Id);

            edit.Ad = data.Ad;
            edit.Aciklama = data.Aciklama;
            db.SaveChanges();
            return RedirectToAction("Index");

            // 2.yol :

            var guncelle = db.Kategori.Where(x => x.Id == data.Id).FirstOrDefault();
            guncelle.Durum = true;
            guncelle.Ad = data.Ad;
            guncelle.Aciklama = data.Aciklama;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "A")]
        public ActionResult Delete(int id)
        {
            var kategori = db.Kategori.Where(x => x.Id == id).FirstOrDefault();
            kategori.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}