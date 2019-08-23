using Spock_Bug_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spock_Bug_Tracker.ViewModels
{
    public class UserProfileViewModel
    {
        public IndexViewModel IndexViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }

    }
}