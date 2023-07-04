﻿using MenuMasterInterface.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuMasterInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenu _iMenu;
        public HomeController(IMenu menu)
        {
            _iMenu = menu;
        }
        public ActionResult Index()
        {
            return View(_iMenu.GetAllMenu());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}