﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index() //RedirectResult, HttpUnauthorizedResult,
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Start = "Start";
            ViewBag.Hello = hour < 12 ? "Good morning" : "Good Afternoon";

            return View();
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
    }
}