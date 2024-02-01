using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class PurchaseOrderLineViewModel
    {
        public int? ProductId { get; set; }
        public int? PurchaseId { get; set; }
        public string? OrderLineDescription { get; set; }
        public int? OrderLineQuantity { get; set; }
        public double? OrderLineUnitPrice { get; set; }
        public double? TaxPercentage { get; set; }
        public double? TotalPrice { get; set; }
    }
}
