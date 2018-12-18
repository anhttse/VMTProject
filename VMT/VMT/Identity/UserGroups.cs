using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VMT.Identity
{
    public class RoleGroup : IdentityRole<string>
    {
        public RoleGroup() : base() { }
        public RoleGroup(string name) : base(name) { }
        public string Description { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
