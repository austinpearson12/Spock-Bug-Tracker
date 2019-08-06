using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TicketId { get; set; }
        public string CommentBody { get; set; }
        public DateTimeOffset Created { get; set; }
        public string AuthorId { get; set; }

        //Nav
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}