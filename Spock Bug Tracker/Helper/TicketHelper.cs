﻿using Spock_Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Helper
{    

    public class TicketHelper
    { 
        ApplicationDbContext db = new ApplicationDbContext();
        UserRolesHelper roleHelper = new UserRolesHelper();

        public bool IsDevOnTicket(string userId, int ticketId)
        {
            var ticket = db.Tickets.Find(ticketId);
            return ticket.AssignedToUserId == userId;
        }

        public void AddDevToTicket(string userId, int ticketId)
        {
            if (!IsDevOnTicket(userId, ticketId))
            {
                Ticket ticket = db.Tickets.Find(ticketId);
                ticket.AssignedToUserId = userId;
                db.SaveChanges();
            }
        }

        public void RemoveDevFromTicket(int ticketId)
        {
            Ticket ticket = db.Tickets.Find(ticketId);
            ticket.AssignedToUserId = null;
            db.SaveChanges();
        }

        public int GetNewTicketStatus(string oldDeveloper, string newDeveloper)
        {
            var newAssignment = string.IsNullOrEmpty(oldDeveloper) && !string.IsNullOrEmpty(newDeveloper);
            var unAssignment = !string.IsNullOrEmpty(oldDeveloper) && string.IsNullOrEmpty(newDeveloper);
            var reAssignment = (!string.IsNullOrEmpty(oldDeveloper) && !string.IsNullOrEmpty(newDeveloper)) && (oldDeveloper != newDeveloper);

            var statusId = -1;
            if (newAssignment)
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "Assigned").Id;
            }
            else if (unAssignment)
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "Unassigned").Id;
            }
            else if (reAssignment)
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "Assigned").Id;
            }
            else if (reAssignment)
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "In Progress").Id;
            }
            else if (reAssignment)
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "Completed").Id;
            }
            else
            {
                statusId = db.TicketStatuses.FirstOrDefault(t => t.Name == "Archived").Id;
            }
            

            return statusId;
        }

        public int CountMyTickets(string userId)
        {
            var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            var userRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            var tix = 420;
            switch (userRole)
            {
                case "Admin":
                    tix = db.Tickets.Count();
                    break;
                case "Developer":
                    tix = db.Tickets.Where(t => t.AssignedToUserId == userId).Count();
                    break;
                case "Submitter":
                    tix = db.Tickets.Where(t => t.OwnerUserId == userId).Count();
                    break;
                case "Project Manager":
                    tix = user.Projects.SelectMany(p => p.Tickets).ToList().Count();
                    break;
                default:
                    break;
            };
            return tix;
        }

        public int CountMyImmediateTickets(string userId)
        {
            var user = db.Users.Where(u => u.Id == userId).FirstOrDefault();
            var userRole = roleHelper.ListUserRoles(userId).FirstOrDefault();
            var tix = 420;
            switch (userRole)
            {
                case "Admin":
                    tix = db.Tickets.Where(t => t.TicketPriority.Name == "Immediate").Count();
                    break;
                case "Developer":
                    tix = db.Tickets.Where(t => t.AssignedToUserId == userId && t.TicketPriority.Name == "Immediate").Count();
                    break;
                case "Submitter":
                    tix = db.Tickets.Where(t => t.OwnerUserId == userId && t.TicketPriority.Name == "Immediate").Count();
                    break;
                case "Project Manager":
                    tix = user.Projects.SelectMany(p => p.Tickets).Where(t => t.TicketPriority.Name == "Immediate").ToList().Count();
                    break;
                default:
                    break;
            };
            return tix;
        }
    }
}