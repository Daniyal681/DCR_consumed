using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.Helper.ViewModel
{
    public class IMEIViewModel
    {
        public int ImeiId { get; set; }
        public int? ProductId { get; set; }
        public string? ImeiNumber { get; set; }
        public string? ImeiNumber2 { get; set; }
        public string? ImeiStatus { get; set; }
        public string? DeviceType { get; set; }
        public DateTime? ActivationDate { get; set; }
    }
}
