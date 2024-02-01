using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class FactoryDelivery
    {
        public int FactoryDeliveryId { get; set; }
        public int? ProductId { get; set; }
        public int? DistributorId { get; set; }
        public DateTime? DeliveryDateTime { get; set; }
        public string? ReceiverName { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
