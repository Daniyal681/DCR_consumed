using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class InboundOrder
    {
        public int InboundId { get; set; }
        public string InboundOrderId { get; set; } = null!;
        public DateTime InboundDate { get; set; }
    }
}
