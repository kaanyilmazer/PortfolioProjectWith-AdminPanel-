﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserRole:IdentityRole<int>
    {
        public const string User = "User";
        public const string Admin = "Admin";
        public const string Mod = "Mod";
    }
}
