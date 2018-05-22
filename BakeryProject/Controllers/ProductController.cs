using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;


namespace BakeryProject.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            //initialize entities classes
            BakeryEntities db = new BakeryEntities();
            //pass the collection categories to the index as a list
            return View(db.Products.ToList());
        }
    }
}