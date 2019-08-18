﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTimeOffset Created { get; set; }
        public string UserId { get; set; }






        //Nav
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}