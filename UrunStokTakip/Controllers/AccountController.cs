using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using UrunStokTakip.Models;

namespace UrunStokTakip.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        Takip_SistemiEntities db = new Takip_SistemiEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanici p)
        {
            var bilgiler = db.Kullanici.FirstOrDefault(x => x.Email == p.Email && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Email, false);
                Session["Mail"] = bilgiler.Email.ToString();
                Session["Ad"] = bilgiler.Ad.ToString();
                Session["Soyad"] = bilgiler.Soyad.ToString();
                
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Kullanici data)
        {
            db.Kullanici.Add(data);
            data.Rol = "U";
            db.SaveChanges();

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Guncelle()
        {
            var kullanicilar = (string)Session["Mail"];
            var degerler = db.Kullanici.FirstOrDefault(x => x.Email == kullanicilar);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Guncelle(Kullanici data)
        {
            var kullanicilar = (string)Session["Mail"];
            var user = db.Kullanici.Where(x => x.Email == kullanicilar).FirstOrDefault();

            user.Ad = data.Ad;
            user.Soyad = data.Soyad;
            user.Email = data.Email;
            user.KullaniciAd = data.KullaniciAd;
            user.Sifre = data.Sifre;
            user.SifreTekrar = data.SifreTekrar;

            db.SaveChanges();
            return RedirectToAction("Index","Home");

        }

        public ActionResult SifreReset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifreReset(string eposta)
        {
            var mail = db.Kullanici.Where(x => x.Email == eposta).SingleOrDefault();
            if (mail != null)
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();
                Kullanici sifre = new Kullanici();
                mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre),"MD5");
                db.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "k-yunus@hotmail.com";
                WebMail.Password = "1234";
                WebMail.SmtpPort = 587;
                WebMail.Send(eposta, "Giriş Şifreniz","Şifreniz:" + yenisifre);
                ViewBag.uyarı = "Şifreniz Başlarıyla Gönderilmiştir";
            }
            else
            {
                ViewBag.uyarı = "Hata Oluştu Tekrar Deneyin";
            }
            return View();
        }
    }
}