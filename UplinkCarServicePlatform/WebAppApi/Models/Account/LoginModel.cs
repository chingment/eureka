﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppApi.Models.Account
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FuselageNumber { get; set; }
    }
}