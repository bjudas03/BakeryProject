using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;

namespace BakeryProject.Controllers
{
    public class LoginController : Controller
    {
        BakeryEntities db = new BakeryEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")]Login l)
        {
            int results = db.usp_Login(l.UserName, l.Password);
            int perKey = 0;
            Message msg = new Message();
            
            if (results != -1)
            {
                var pkey = (from p in db.People
                            where p.PersonEmail.Equals(l.UserName)
                            select p.PersonKey).FirstOrDefault();
                perKey = (int)pkey;
                Session["Personkey"] = perKey;

                msg.MessageText = "Welcome, " + l.UserName;
            }
            else
            {
                msg.MessageText = "Invalid Login";
            }
            return View("Result", msg);

        }

        public ActionResult Result(Message msg)
        {
            return View();
        }

    }

}