using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Receive
    {
        public int ReceiveId { get; set; }
        public int? DistributorId { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Distributor? Distributor { get; set; }
    }
}
