using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class UserProfileViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
