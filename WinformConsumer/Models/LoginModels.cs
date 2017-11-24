﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformConsumer.Models
{
    public class LoginModels
    {
        public class ValidUser
        {
            public int UserPK { get; set; }
            public string LoginUserName { get; set; }
            public string LoginUserPassword { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int AuthGroup { get; set; }
            public int AuthDepartment { get; set; }
            public string GmailAddress { get; set; }
            public string GMailPassword { get; set; }
        }
    }
}
