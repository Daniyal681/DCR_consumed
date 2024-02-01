using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string? OrderType { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderDescription { get; set; }
        public double? ShippingCharges { get; set; }
        public int? Quantity { get; set; }
        public double? SubTotal { get; set; }
        public double? Discount { get; set; }
        public double? Tax { get; set; }
        public double? Total { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryStatus { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? DeliveryRecipient { get; set; }
        public string? BillingAddress { get; set; }
        public int? SalePersonId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual SalesPerson? SalePerson { get; set; }
    }
}
