using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int VendorId { get; set; }
        public int ContactPersonId { get; set; }
        public string VendorName { get; set; } = null!;
        public string? VendorEmail { get; set; }
        public string VendorPhone { get; set; } = null!;
        public string VendorAddress { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string VendorCity { get; set; } = null!;
        public string? VendorState { get; set; }
        public string? VendorPostalCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ContactPerson ContactPerson { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
