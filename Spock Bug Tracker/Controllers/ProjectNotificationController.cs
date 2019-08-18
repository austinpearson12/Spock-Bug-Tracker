using Spock_Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spock_Bug_Tracker.Controllers
{
    public class ProjectNotificationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ProjectNotification
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjectId,UserId,NotificationBody,Created,Unread")] ProjectNotification projectNotification)
        {
            if (ModelState.IsValid)
            {
                db.ProjectNotifications.Add(projectNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectNotification.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", projectNotification.UserId);
            return View(projectNotification);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjectId,UserId,NotificationBody,Created,Unread")] ProjectNotification projectNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectNotification.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", projectNotification.UserId);
            return View(projectNotification);

        }
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