using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BakeryProject.Models;

namespace BakeryProject.Controllers
{
    public class RegisterController : Controller
    {
        BakeryEntities db = new BakeryEntities();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail," +
                                                  "PersonPhone, PersonDateAdded, PersonPassword," +
                                                  "PersonIdentityCode")] Person p)

        {
            Message msg = new Message();
            int result = db.usp_newPerson(p.PersonLastName,p.PersonFirstName,p.PersonEmail,p.PersonPhone,
                p.PersonPassword);
            if (result != -1)
            {
                msg.MessageText = "Welcome! Congrats on Registering, " + p.PersonFirstName + " " + p.PersonLastName;
            }
            else
            {
                msg.MessageText = "Something went wrong! You need to try again.";
            }

            return View("Result", msg);

        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}