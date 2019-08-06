﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class TicketNotification
    {
        public int Id { get; set; }
        public string TicketId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Subject { get; set; }
        public string NotificationBody { get; set; }
        public string RecipientId { get; set; }
        public string SenderId { get; set; }
        public bool IsRead { get; set; }





        //Nav
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser Recipient { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}