using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel.ViewModel
{
    public class PaymentViewModel
    {
        public int? DistributorId { get; set; }
        public double? PaymentAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentDescription { get; set; }
    }
}
