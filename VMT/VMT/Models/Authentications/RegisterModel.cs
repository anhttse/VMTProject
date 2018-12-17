using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VMT.Models.Authentications
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
