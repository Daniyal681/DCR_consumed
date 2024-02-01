using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Role
    {
        public Role()
        {
            MenuPermissionAssigns = new HashSet<MenuPermissionAssign>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<MenuPermissionAssign> MenuPermissionAssigns { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
