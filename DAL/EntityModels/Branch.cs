using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Branch
    {
        public Branch()
        {
            Warehouses = new HashSet<Warehouse>();
        }

        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchPerson { get; set; }
        public string? BranchEmail { get; set; }
        public string? BranchPhone { get; set; }
        public string? BranchAddress { get; set; }
        public string? Country { get; set; }
        public string? BranchCity { get; set; }
        public string? BranchState { get; set; }
        public string? BranchPostalCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
