﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VMT.Identity
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    }
}
