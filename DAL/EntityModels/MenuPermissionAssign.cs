using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class MenuPermissionAssign
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? MenuListId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Dum? MenuList { get; set; }
        public virtual MenuList? MenuListNavigation { get; set; }
        public virtual Role? Role { get; set; }
    }
}
