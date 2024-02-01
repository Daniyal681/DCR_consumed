using System;
using System.Collections.Generic;


namespace DAL.Models
{
    public partial class ProductDistributor
    {
        public int ProductDistributorId { get; set; }
        public int DistributorId { get; set; }
        public int ImeiId { get; set; }

        public virtual Distributor Distributor { get; set; } = null!;
    }
}
