using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class PurchaseOrderDetailViewModel
    {
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double? Total { get; set; }
    }
}
