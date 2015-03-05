using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Transaction1.Models;

namespace MVC_Transaction1.ViewModels
{
    public class UserInformation
    {
        public User Users { get; set; }

        public Role Roles { get; set; }

        public UserProfile UserProfiles { get; set; }

        public UserRole UserRoles { get; set; }

        public SecurityQuestion SecurityQuestions { get; set; }

        public UserSecurityQuestion UserSecurityQuestions { get; set; }
    }
}