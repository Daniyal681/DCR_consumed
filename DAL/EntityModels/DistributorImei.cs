using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class DistributorImei
    {
        public int DistributorImeiId { get; set; }
        public int? DistributorId { get; set; }
        public int? ImeiId { get; set; }

        public virtual Distributor? Distributor { get; set; }
        public virtual Imei? Imei { get; set; }
    }
}
