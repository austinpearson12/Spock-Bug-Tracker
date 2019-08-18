using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        
        public int TicketId { get; set; }
        [StringLength(250, MinimumLength = 4, ErrorMessage = "The Comment Body must be between 4 and 250 characters long.")]
        public string CommentBody { get; set; }
        public DateTimeOffset Created { get; set; }
        public string AuthorId { get; set; }

        //Nav
        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}