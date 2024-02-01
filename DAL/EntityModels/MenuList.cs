using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class MenuList
    {
        public MenuList()
        {
            MenuPermissionAssigns = new HashSet<MenuPermissionAssign>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public bool? HasChildren { get; set; }
        public int? SortOrder { get; set; }
        public string? NavigationUrl { get; set; }
        public string? IconClass { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? ParentName { get; set; }

        public virtual ICollection<MenuPermissionAssign> MenuPermissionAssigns { get; set; }
    }
}
