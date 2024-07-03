using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunStokTakip.Models;
using PagedList.Mvc;

namespace UrunStokTakip.Controllers
{
    public class TumSatislarController : Controller
    {
        Takip_SistemiEntities db = new Takip_SistemiEntities();

        // GET: TümSatislar

        [Authorize(Roles ="A")]
        public ActionResult Index(int sayfa=1)
        {
            return View(db.Satislar.ToList().ToPagedList(sayfa,5));
        }
    }
}