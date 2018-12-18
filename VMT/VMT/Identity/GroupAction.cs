using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VMT.Identity
{
    public class GroupAction
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
