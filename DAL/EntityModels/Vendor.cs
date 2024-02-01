using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Vendor
    {
        public Vendor()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int VendorId { get; set; }
        public int? ContactPersonId { get; set; }
        public string? VendorName { get; set; }
        public string? VendorEmail { get; set; }
        public string? VendorPhone { get; set; }
        public string? VendorAddress { get; set; }
        public string? Country { get; set; }
        public string? VendorCity { get; set; }
        public string? VendorState { get; set; }
        public string? VendorPostalCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ContactPerson? ContactPerson { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
