using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class LoginViewModel
    {
        public int UserId { get; set; }
        public string? UserLoginId { get; set; }
        public string? UserPassword { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserContact { get; set; }
        public int RoleId { get; set; }

    }
}
