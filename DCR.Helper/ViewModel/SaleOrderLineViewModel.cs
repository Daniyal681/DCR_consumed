using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class SaleOrderLineViewModel
    {
        public int? SalesOrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public double? UnitPrice { get; set; }
        public double? Total { get; set; }
    }
}
