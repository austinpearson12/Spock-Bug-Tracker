using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Spock_Bug_Tracker.Models;

namespace Spock_Bug_Tracker.Controllers
{
    public class TaskItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void MarkAsDone(int id)
        {
            var myItem = db.TaskItems.Find(id);
            myItem.IsChecked = !myItem.IsChecked;
            db.SaveChanges();
        }

        // GET: TaskItems
        //public ActionResult Index()
        //{
        //    var taskItems = db.TaskItems.Include(t => t.User);
        //    return View(taskItems.ToList());
        //}

        //// GET: TaskItems/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaskItem taskItem = db.TaskItems.Find(id);
        //    if (taskItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taskItem);
        //}

        //// GET: TaskItems/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName");
        //    return View();
        //}

        // POST: TaskItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Name,IsChecked")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                taskItem.UserId = User.Identity.GetUserId();
                db.TaskItems.Add(taskItem);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Home");
            }

            //ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", toDoListItem.UserId);
            return View(taskItem);
        }
        //// GET: TaskItems/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaskItem taskItem = db.TaskItems.Find(id);
        //    if (taskItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", taskItem.UserId);
        //    return View(taskItem);
        //}

        //// POST: TaskItems/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserId,Name,IsChecked")] TaskItem taskItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(taskItem).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "FirstName", taskItem.UserId);
        //    return View(taskItem);
        //}

        //// GET: TaskItems/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaskItem taskItem = db.TaskItems.Find(id);
        //    if (taskItem == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taskItem);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomDelete()
        {
            var userId = User.Identity.GetUserId();
            foreach (var item in db.TaskItems.Where(i => i.UserId == userId && i.IsChecked))
            {
                db.TaskItems.Remove(item);
            }
            db.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }

        //// POST: TaskItems/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    TaskItem taskItem = db.TaskItems.Find(id);
        //    db.TaskItems.Remove(taskItem);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
