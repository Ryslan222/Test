﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        ItemContext db = new ItemContext();
        public ActionResult Index()
        {
            IEnumerable<Item> items = db.Items;
            ViewBag.Items = items;

            return View();

        }
        [HttpGet]
        public ActionResult Send ()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Send(Item Item)
        {
           
            
            db.Items.Add(Item);            
            db.SaveChanges();
            return View();
           
        }

    }

}