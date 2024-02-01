using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class Customer
    {
        public Customer()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string CustomerPhone { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string CustomerCountry { get; set; } = null!;
        public string? CustomerState { get; set; }
        public string CustomerCity { get; set; } = null!;
        public string? CustomerPostalCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
