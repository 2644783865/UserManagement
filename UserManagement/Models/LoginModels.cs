using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class LoginModels
    {
        public string user_email { get; set; }
        public string user_password { get; set; }
    }

    public class SuccessLogin
    {
        public string user_email { get; set; }
        public string user_password { get; set; }
    }
}