using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class ReturnProduct
    {
        public int ReturnId { get; set; }
        public int ProductId { get; set; }
        public int DistributorId { get; set; }
        public DateTime ReturnDateTime { get; set; }
        public int QuantityReturned { get; set; }
        public string ReceiverName { get; set; } = null!;
        public string? ReasonForReturn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
