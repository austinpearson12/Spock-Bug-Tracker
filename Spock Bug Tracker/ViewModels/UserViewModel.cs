using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.ViewModels
{
    public class UserViewModel
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Display Name")]
        public string DisplayName { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public HttpPostedFileBase Avatar { get; set; }

        public string AvatarUrl { get; set; }
    }
}