using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class ProductWarehouse
    {
        public int ProductWarehouseId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseTypeId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehouse WarehouseType { get; set; } = null!;
    }
}
