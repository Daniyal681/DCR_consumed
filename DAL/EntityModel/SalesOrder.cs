using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            SaleOrderLines = new HashSet<SaleOrderLine>();
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int SalesOrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string Status { get; set; } = null!;
        public double Total { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
