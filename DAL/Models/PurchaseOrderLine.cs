using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PurchaseOrderLine
    {
        public int OrderLineId { get; set; }
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public string? OrderLineDescription { get; set; }
        public int OrderLineQuantity { get; set; }
        public double OrderLineUnitPrice { get; set; }
        public double TaxPercentage { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual PurchaseOrder Purchase { get; set; } = null!;
    }
}
