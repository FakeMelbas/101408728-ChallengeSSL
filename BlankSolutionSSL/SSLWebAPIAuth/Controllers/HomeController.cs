﻿using Microsoft.AspNet.Identity;
using SSLWebAPIAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLWebAPIAuth.Controllers
{
    [RequireHttps]
    public class HomeController : Controller

    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult YourModules()
        {
            ViewBag.Message = "Here are the modules you are responsible for:";

            var userId = User.Identity.GetUserId();
            List<UserModule> modules = new List<UserModule>(db.UserModules.Where(u => u.Id == userId));

            ViewBag.Modules = modules;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}