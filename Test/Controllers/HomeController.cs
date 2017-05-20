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

            Item.FirstData = DateTime.Now;
            db.Items.Add(Item);            
            db.SaveChanges();
            return RedirectToAction("Index");
           
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
            if(item.IsComplate==true)
            {
                item.LastData = DateTime.Now;
            }

         
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Item b = db.Items.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item b = db.Items.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Items.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}