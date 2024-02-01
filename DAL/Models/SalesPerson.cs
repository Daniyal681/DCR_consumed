using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            Orders = new HashSet<Order>();
        }

        public int SalePersonId { get; set; }
        public int UserProfileId { get; set; }
        public string SalesRegion { get; set; } = null!;
        public double CommissionRate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual UserProfile UserProfile { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
