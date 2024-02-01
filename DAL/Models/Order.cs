using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string OrderType { get; set; } = null!;
        public string OrderStatus { get; set; } = null!;
        public string? OrderDescription { get; set; }
        public double ShippingCharges { get; set; }
        public int Quantity { get; set; }
        public double SubTotal { get; set; }
        public double? Discount { get; set; }
        public double? Tax { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public string BillingAddress { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public int SalePersonId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual SalesPerson SalePerson { get; set; } = null!;
    }
}
