using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class ReceiveViewModel
    {
        public int? DistributorId { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }
    }
}
