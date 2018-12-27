using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace VMT.Identity.Authorize
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string PerAction { get; set; }

        public PermissionAuthorizationRequirement()
        {
        }
        //Add any custom requirement properties if you have them
    }
}
