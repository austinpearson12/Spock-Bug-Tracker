﻿using Microsoft.AspNet.Identity;
using Spock_Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Helper
{
    public class NotificationHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        public static void CreateAssignmentNotification(Ticket oldTicket, Ticket newTicket)
        {
            var noChange = (oldTicket.AssignedToUserId == newTicket.AssignedToUserId);
            var assignment = (string.IsNullOrEmpty(oldTicket.AssignedToUserId));
            var unassignment = (string.IsNullOrEmpty(newTicket.AssignedToUserId));

            if (noChange)
                return;

            if (assignment)
                GenerateAssignmentNotification(oldTicket, newTicket);
            else if(unassignment)
                GenerateUnAssignmentNotification(oldTicket, newTicket);
            else
            {
                GenerateAssignmentNotification(oldTicket, newTicket);
                GenerateUnAssignmentNotification(oldTicket, newTicket);
            }
        }
        private static void GenerateUnAssignmentNotification(Ticket oldTicket, Ticket newTicket)
        {
            var notification = new TicketNotification
            {
                Created = DateTime.Now,
                Subject = $"You were unassigned from Ticket Id {newTicket.Id} on {DateTime.Now}",
                IsRead = false,
                RecipientId = oldTicket.AssignedToUserId,
                SenderId = HttpContext.Current.User.Identity.GetUserId(),
                NotificationBody = $"Please acknowledge that you have read this notification by marking it Read",
                TicketId = newTicket.Id

            };
            db.TicketNotifications.Add(notification);
            db.SaveChanges();
        }
        private static void GenerateAssignmentNotification(Ticket oldTicket, Ticket newTicket)
        {
            var notification = new TicketNotification
            {
                Created = DateTime.Now,
                Subject = $"You were assigned to Ticket Id {newTicket.Id} on {DateTime.Now}",
                IsRead = false,
                RecipientId = newTicket.AssignedToUserId,
                SenderId = HttpContext.Current.User.Identity.GetUserId(),
                NotificationBody = $"Please acknowledge that you have read this notification by marking it Read",
                TicketId = newTicket.Id

            };
            db.TicketNotifications.Add(notification);
            db.SaveChanges();
        }
        public List<TicketNotification>GetUnreadUserNotifications()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return db.TicketNotifications.Where(t => t.RecipientId == userId && !t.IsRead).ToList();
        }
        public static int GetNewUserNotificationCount()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return db.TicketNotifications.Where(t => t.RecipientId == userId && !t.IsRead).Count();
        }
        public static int GetAllUserNotificationCount()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return db.TicketNotifications.Where(t => t.RecipientId == userId).Count();
        }
    }
}