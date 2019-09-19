using Spock_Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.ViewModels
{
    public class UserViewModel
    {
        [Required(AllowEmptyStrings = false), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false), Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Required(AllowEmptyStrings = false), EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        

        public string AvatarUrl { get; set; }
        public IndexViewModel IndexViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
    }  
}