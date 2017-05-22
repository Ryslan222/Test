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
            IEnumerable<Item> items = db.Items.OrderBy(i => i.IsComplate).ThenByDescending(i => i.rating);
            ViewBag.Items = items;

            return View();

        }
        [HttpGet]
        public ActionResult Send()
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
            if (item.IsComplate == true)
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
        [HttpGet]
        public ActionResult Activ()
        {
            IEnumerable<Item> items = db.Items.Where(i => i.IsComplate).ToList();
            ViewBag.Items = items;

            return View();
        }

        [HttpGet]
        public ActionResult Sub(int? Id)
        {
            ViewBag.ItemId = Id;
            return View();
        }
        [HttpPost]
        public ActionResult Sub(SubTask SubTask)
        {

            db.SubTasks.Add(SubTask);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Sub1(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Item item = db.Items.Include(t => t.Subtasks).FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            IEnumerable<SubTask> SubTasks = db.SubTasks.OrderBy(i => i.order);
            ViewBag.SubTasks = SubTasks;

            return View(item);
        }
        public ActionResult DeletSub(int id)
        {
            SubTask b = db.SubTasks.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("DeletSub")]
        public ActionResult DeletSubConfirmed(int id)
        {
            SubTask b = db.SubTasks.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.SubTasks.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SendTag()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SendTag(Tag Tag)
        {
            db.Tag.Add(Tag);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int? id )
        {
            Item Item = db.Items.Find(id);
            if (Item == null)
            {
                return HttpNotFound();
            }
            return View(Item);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Edit(int? id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Tag = db.Tag.ToList();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item Item, int[] selectedTag)
        {
            Item newItem = db.Items.Find(Item.Id);
            newItem.name = Item.name;
            newItem.rating = Item.rating;

            newItem.Tag.Clear();
            if (selectedTag != null)
            {
              
                foreach (var c in db.Tag.Where(co => selectedTag.Contains(co.Id)))
                {
                    newItem.Tag.Add(c);
                }
            }

            db.Entry(newItem).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}