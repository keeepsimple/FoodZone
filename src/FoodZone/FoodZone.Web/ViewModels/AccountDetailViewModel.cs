﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodZone.Web.ViewModels
{
    public class AccountDetailViewModel
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int Level { get; set; }
    }
}