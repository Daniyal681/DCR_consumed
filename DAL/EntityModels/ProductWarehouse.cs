using System;
using System.Collections.Generic;

namespace DAL.EntityModels
{
    public partial class ProductWarehouse
    {
        public int ProductWarehouseId { get; set; }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
    }
}
