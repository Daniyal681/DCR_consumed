using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class User
    {
        public User()
        {
            UserProfiles = new HashSet<UserProfile>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string? UserLoginId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? Salt { get; set; }
        public string? ContactNo { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
