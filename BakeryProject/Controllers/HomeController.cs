﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;

//test merge
namespace BakeryProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BakeryEntities db = new BakeryEntities();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //this is a comment
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}