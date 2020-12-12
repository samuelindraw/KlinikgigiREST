using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Models
{
    public class User
    {

        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string rolename { get; set; }
        public string TenantID { get; set; }
        public string TenantName { get; set; }

    }
}
