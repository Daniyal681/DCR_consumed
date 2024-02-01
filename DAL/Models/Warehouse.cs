using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            ProductWarehouses = new HashSet<ProductWarehouse>();
        }

        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string? WarehouseDescription { get; set; }
        public string WarehouseType { get; set; } = null!;
        public int BranchId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual ICollection<ProductWarehouse> ProductWarehouses { get; set; }
    }
}
