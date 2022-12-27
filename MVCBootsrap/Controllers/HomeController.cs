using MVCBootsrap.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBootsrap.Controllers
{
    public class HomeController : Controller
    {
        ToDoListEntities db = new ToDoListEntities();
        // GET: Home
        
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Index()
        {
            var model = db.To_Do_List.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            var model=db.To_Do_List.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(To_Do_List order)
        {
            if (order.ID==0)
            {
                db.To_Do_List.Add(order);
            }
            else
            {
                var updateData = db.To_Do_List.Find(order.ID);
                if (updateData==null)
                {
                    return HttpNotFound();
                }
                updateData.TaskName=order.TaskName;
            }
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Update(int id)
        {
            var model = db.To_Do_List.Find(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View("New",model);
        }

        public ActionResult Delete(int id)
        {
            var deleteOrder=db.To_Do_List.Find(id);
            if (deleteOrder == null)
            {
                return HttpNotFound();
            }
            db.To_Do_List.Remove(deleteOrder);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}