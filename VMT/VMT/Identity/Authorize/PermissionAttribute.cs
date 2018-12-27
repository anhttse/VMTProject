using System;
using Microsoft.AspNetCore.Authorization;

namespace VMT.Identity.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class PermissionAttribute : AuthorizeAttribute
    {
        
        public string GroupName { get; set; }
        public string GroupAction { get; set; }


        public PermissionAttribute()
        {
            Policy = "Permission";
        }

        public PermissionAttribute(string grName,string grAction) : base("Permission")
        {
            GroupName = grName;
            GroupAction = grAction;
        }
    }
}
