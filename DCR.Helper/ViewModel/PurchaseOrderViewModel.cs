using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class PurchaseOrderViewModel
    {
        public int? VendorId { get; set; }
        public string? PurchaseName { get; set; }
        public string? PurchaseQuantity { get; set; }
        public string? PurchaseDescription { get; set; }
        public DateTime? DateOfOrder { get; set; }
        public DateTime? DateOfDelivery { get; set; }
        public double? Amount { get; set; }
        public double? SubTotal { get; set; }
        public double? Discount { get; set; }
        public double? Total { get; set; }
    }
}
