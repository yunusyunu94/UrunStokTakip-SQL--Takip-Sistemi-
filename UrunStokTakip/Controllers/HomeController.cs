﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrunStokTakip.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}