using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        MyProduct product = new MyProduct
            {Name = "OnePlus 5", Price = 480};

        // GET: Home
        public ViewResult Index() //RedirectResult, HttpUnauthorizedResult,
        {

            int hour = DateTime.Now.Hour;
            ViewBag.Start = "Start";
            ViewBag.Hello = hour < 12 ? "Good morning" : "Good Afternoon";

            return View(product);
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        public ActionResult NameAndPrice()
        {
            return View(product);
        }

        public ActionResult DemoExpressions()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.AplyDiscount = false;
            ViewBag.Supplier = null;
            return View(product);
        }

        public ActionResult DemoArray()
        {
            MyProduct[] array =
            {
                new MyProduct {Name = "Kayak", Price = 275},
                new MyProduct {Name = "Lifejacket", Price = 48},
                new MyProduct {Name = "Soccer ball", Price = 19},
                new MyProduct {Name = "Corner flag", Price = 34}
            };
            return View(array);
        }
    }
}