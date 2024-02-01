using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class SalesOrderDetail
    {
        public int OrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double SubTotal { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual SalesOrder SalesOrder { get; set; } = null!;
    }
}
