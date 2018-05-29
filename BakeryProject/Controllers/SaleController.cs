using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;

namespace BakeryProject.Controllers
{
    public class SaleController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        // GET: GrantApplication
        public ActionResult Index()
        {
            if (Session["ReviewerKey"] == null)
            {
                //Message msg = new Message("You must be logged in to add a sale");
                //return RedirectToAction("Result", msg");

                return RedirectToAction("Index", "Login");
            }
            ViewBag.Grants = new SelectList(db.Products, "ProductKey", "ProductName","ProductPrice");
            return View();

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "SaleKey,CustomerKey,EmployeeKey,GrantApplicationRequestAmount,GrantApplicationReason," +
            "GrantApplicationStatusKey")]GrantApplication g)
        {
            try
            {
                g.GrantAppicationDate = DateTime.Now;
                g.PersonKey = (int)Session["ReviewerKey"];
                g.GrantApplicationStatusKey = (int)1;

                db.GrantApplications.Add(g);
                db.SaveChanges();

                Message msg = new Message("Thank you for your purchase");
                return RedirectToAction("Result", msg);

            }
            catch (Exception e)
            {
                Message msg = new Message();
                msg.MessageText = e.Message;
                return RedirectToAction("Result", msg);
            }

        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }
}