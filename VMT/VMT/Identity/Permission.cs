using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VMT.Identity
{
    public class Permission
    {
        public Permission()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Permission(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        [Key]
        public string Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public virtual ICollection<RoleGrouPermission> RoleGrouPermission { get; set; }
        public virtual ICollection<PermissionAction> PermissionAction { get; set; }
    }
}
