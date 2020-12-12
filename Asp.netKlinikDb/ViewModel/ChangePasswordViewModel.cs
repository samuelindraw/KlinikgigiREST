using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int Status { get; set; }
    }
}
