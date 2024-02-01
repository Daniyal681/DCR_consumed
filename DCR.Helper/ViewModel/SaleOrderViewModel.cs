using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class SaleOrderViewModel
    {
        public int? CustomerId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string? Status { get; set; }
        public double? Total { get; set; }
    }
}
