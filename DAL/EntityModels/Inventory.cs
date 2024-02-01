using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int TotalInventory { get; set; }
        public int ActiveInventory { get; set; }
        public int InActiveInventory { get; set; }
        public int InventoryDuration { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
