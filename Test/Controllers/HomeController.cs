using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Item itemm = db.Items.Find(id);
            if (itemm != null)
            {
                return View(itemm);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}