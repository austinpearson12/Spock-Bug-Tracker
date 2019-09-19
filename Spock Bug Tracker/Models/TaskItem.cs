using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}