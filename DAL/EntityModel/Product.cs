using System;
using System.Collections.Generic;

namespace DAL.EntityModel
{
    public partial class Product
    {
        public Product()
        {
            Imeis = new HashSet<Imei>();
            ProductWarehouses = new HashSet<ProductWarehouse>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SaleOrderLines = new HashSet<SaleOrderLine>();
            SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int MaterialId { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public string ProductSku { get; set; } = null!;
        public string ProductCode { get; set; } = null!;
        public string MarketName { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Memory { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Series { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ProductType ProductType { get; set; } = null!;
        public virtual ICollection<Imei> Imeis { get; set; }
        public virtual ICollection<ProductWarehouse> ProductWarehouses { get; set; }
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}
