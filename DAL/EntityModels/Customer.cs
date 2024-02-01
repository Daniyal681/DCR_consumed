using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Customer
    {
        public Customer()
        {
            SalesOrders = new HashSet<SalesOrder>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerType { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCountry { get; set; }
        public string? CustomerState { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerPostalCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
    }
}
