﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class Ticket
    {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTimeOffset Created { get; set; }
            public DateTimeOffset? Updated { get; set; }
            public int TicketTypeId { get; set; }
            public int ProjectId { get; set; }
            public int TicketPriorityId { get; set; }
            public int TicketStatusId { get; set; }
            public string OwnerUserId { get; set; }
            public string AssignedToUserId { get; set; }
            public bool Deleted { get; set; }

        //Virtual Nav Section
            public virtual TicketType TicketType { get; set; }   
            public virtual Project Project { get; set; }
            public virtual TicketPriority TicketPriority { get; set; }
            public virtual TicketStatus TicketStatus{ get; set; }       
            public virtual ApplicationUser OwnerUser { get; set; }
            public virtual ApplicationUser AssignedToUser { get; set; }

            //Icollections
            public virtual ICollection<TicketComment> TicketComments { get; set; }
            public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
            public virtual ICollection<TicketHistory> TicketHistories { get; set; }
            public virtual ICollection<TicketNotification> TicketNotifications { get; set; }

        //Conctructor
        public Ticket()
            {
                TicketComments = new HashSet<TicketComment>();
                TicketAttachments = new HashSet<TicketAttachment>();
                TicketHistories = new HashSet<TicketHistory>();
                TicketNotifications = new HashSet<TicketNotification>();
            }

        }
    }
