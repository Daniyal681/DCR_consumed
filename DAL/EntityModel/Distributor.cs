using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class Distributor
    {
        public Distributor()
        {
            DistributorImeis = new HashSet<DistributorImei>();
            Payments = new HashSet<Payment>();
            Receives = new HashSet<Receive>();
        }

        public int DistributorId { get; set; }
        public int ContactPersonId { get; set; }
        public string DistributorName { get; set; } = null!;
        public string DistributorType { get; set; } = null!;
        public string? DistributorEmail { get; set; }
        public string DistributorPhone { get; set; } = null!;
        public string? DistributorAddress { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ContactPerson ContactPerson { get; set; } = null!;
        public virtual ICollection<DistributorImei> DistributorImeis { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Receive> Receives { get; set; }
    }
}
