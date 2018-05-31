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
            if (Session["PersonKey"] == null)
            {
                //Message msg = new Message("You must be logged in to add a sale");
                //return RedirectToAction("Result", msg");

                return RedirectToAction("Index", "Login");
            }
            return View(db.Products.ToList());

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "SaleKey,ProductKey,SaleDetailPriceCharged, SaleDetailQuantity, SaleDetailDiscount, SaleDetailSaleTaxPercent, SaleDetailEatInTax")]SaleDetail s)
        {
            try
            {
                Sale sale = new Sale();
                sale.SaleDate = DateTime.Now;
                sale.CustomerKey = (int)Session["PersonKey"];
                sale.EmployeeKey = (int)2;
                s.Sale = sale; 


                s.SaleDetailDiscount = (int)0;
                s.SaleDetailSaleTaxPercent = (decimal).1;
                s.SaleDetailEatInTax = (decimal).1;
                db.SaleDetails.Add(s);
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