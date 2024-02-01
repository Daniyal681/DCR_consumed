using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Imei
    {
        public Imei()
        {
            DistributorImeis = new HashSet<DistributorImei>();
        }

        public int ImeiId { get; set; }
        public int? ProductId { get; set; }
        public string? ImeiNumber { get; set; }
        public string? ImeiNumber2 { get; set; }
        public string? ImeiStatus { get; set; }
        public string? DeviceType { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<DistributorImei> DistributorImeis { get; set; }
    }
}
