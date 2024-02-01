using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            SalesPeople = new HashSet<SalesPerson>();
        }

        public int UserProfileId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<SalesPerson> SalesPeople { get; set; }
    }
}
