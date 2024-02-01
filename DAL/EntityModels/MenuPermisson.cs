using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class MenuPermisson
    {
        public int MenuAssignId { get; set; }
        public int? RoleId { get; set; }
        public int? MenuListId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual MenuList? MenuList { get; set; }
        public virtual Role? Role { get; set; }
    }
}
