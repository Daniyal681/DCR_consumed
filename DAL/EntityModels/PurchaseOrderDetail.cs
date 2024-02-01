using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class PurchaseOrderDetail
    {
        public int PurchaseOrderDetailId { get; set; }
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double? Total { get; set; }

        public virtual Product? Product { get; set; }
        public virtual PurchaseOrder? Purchase { get; set; }
    }
}
