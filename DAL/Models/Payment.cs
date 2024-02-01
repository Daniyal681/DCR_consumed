using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int DistributorId { get; set; }
        public double PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentDescription { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Distributor Distributor { get; set; } = null!;
    }
}
