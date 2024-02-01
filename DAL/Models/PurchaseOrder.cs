using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
        }

        public int PurchaseId { get; set; }
        public int VendorId { get; set; }
        public string PurchaseName { get; set; } = null!;
        public string PurchaseQuantity { get; set; } = null!;
        public string? PurchaseDescription { get; set; }
        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double? Discount { get; set; }
        public double Total { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Vendor Vendor { get; set; } = null!;
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}
