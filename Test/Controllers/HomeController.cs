using System;
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
        [HttpPost]
        public string Send(Item Item)
        {
           
            // добавляем информацию о покупке в базу данных
            db.Items.Add(Item);
            // сохраняем в бд все изменения
            db.SaveChanges();
           
        }

    }

}