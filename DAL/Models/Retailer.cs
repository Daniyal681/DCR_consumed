using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Retailer
    {
        public int RetailerId { get; set; }
        public string RetailerName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string SalesRegion { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
