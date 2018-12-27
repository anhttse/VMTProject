using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VMT.Identity
{
    public class RoleGrouPermission
    {
        [Key, Column(Order = 0),ForeignKey("RoleGroup")]
        public string RoleGroupId { get; set; }
        [Key, Column(Order = 1), ForeignKey("Permission")]
        public string PermissionId { get; set; }

        
        public virtual RoleGroup RoleGroup { get; set; }

        public virtual Permission Permission { get; set; }
    }
}
