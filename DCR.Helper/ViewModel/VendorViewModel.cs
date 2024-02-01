using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class VendorViewModel
    {
        public int? ContactPersonId { get; set; }
        public string? VendorName { get; set; }
        public string? VendorEmail { get; set; }
        public string? VendorPhone { get; set; }
        public string? VendorAddress { get; set; }
        public string? Country { get; set; }
        public string? VendorCity { get; set; }
        public string? VendorState { get; set; }
        public string? VendorPostalCode { get; set; }

    }
}
