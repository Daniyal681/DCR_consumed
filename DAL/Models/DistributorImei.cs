using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class DistributorImei
    {
        public int DistributorImeiId { get; set; }
        public int DistributorId { get; set; }
        public int ImeiId { get; set; }

        public virtual Distributor Distributor { get; set; } = null!;
        public virtual Imei Imei { get; set; } = null!;
    }
}
