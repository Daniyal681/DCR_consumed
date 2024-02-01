using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.EntityModel
{
    public partial class EMS_ITCContext : DbContext
    {
        public EMS_ITCContext()
        {
        }

        public EMS_ITCContext(DbContextOptions<EMS_ITCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<ContactPerson> ContactPeople { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Distributor> Distributors { get; set; } = null!;
        public virtual DbSet<DistributorImei> DistributorImeis { get; set; } = null!;
        public virtual DbSet<FactoryDelivery> FactoryDeliveries { get; set; } = null!;
        public virtual DbSet<Imei> Imeis { get; set; } = null!;
        public virtual DbSet<InboundOrder> InboundOrders { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<ProductWarehouse> ProductWarehouses { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = null!;
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; } = null!;
        public virtual DbSet<Receive> Receives { get; set; } = null!;
        public virtual DbSet<Retailer> Retailers { get; set; } = null!;
        public virtual DbSet<ReturnProduct> ReturnProducts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SaleOrderLine> SaleOrderLines { get; set; } = null!;
        public virtual DbSet<SalesOrder> SalesOrders { get; set; } = null!;
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;
        public virtual DbSet<SalesPerson> SalesPeople { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SAKREN7;Database=EMS_ITC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchId).HasColumnName("Branch_Id");

                entity.Property(e => e.BranchAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Address");

                entity.Property(e => e.BranchCity)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_City");

                entity.Property(e => e.BranchEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Email");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Name");

                entity.Property(e => e.BranchPerson)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Person");

                entity.Property(e => e.BranchPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_Phone");

                entity.Property(e => e.BranchPostalCode)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_PostalCode");

                entity.Property(e => e.BranchState)
                    .HasMaxLength(50)
                    .HasColumnName("Branch_State");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("Update_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("ContactPerson");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPerson_id");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(100)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerCity)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_City");

                entity.Property(e => e.CustomerCountry)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_Country");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_Email");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_Phone");

                entity.Property(e => e.CustomerPostalCode)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_PostalCode");

                entity.Property(e => e.CustomerState)
                    .HasMaxLength(50)
                    .HasColumnName("Customer_State");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.ToTable("Distributor");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPerson_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributorAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Distributor_Address");

                entity.Property(e => e.DistributorEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Distributor_Email");

                entity.Property(e => e.DistributorName)
                    .HasMaxLength(50)
                    .HasColumnName("Distributor_Name");

                entity.Property(e => e.DistributorPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Distributor_Phone");

                entity.Property(e => e.DistributorType)
                    .HasMaxLength(50)
                    .HasColumnName("Distributor_Type");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.Distributors)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Distributor_ContactPerson");
            });

            modelBuilder.Entity<DistributorImei>(entity =>
            {
                entity.ToTable("DistributorIMEI");

                entity.Property(e => e.DistributorImeiId).HasColumnName("DistributorIMEI_Id");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.ImeiId).HasColumnName("IMEI_Id");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.DistributorImeis)
                    .HasForeignKey(d => d.DistributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDistributor_Distributor");

                entity.HasOne(d => d.Imei)
                    .WithMany(p => p.DistributorImeis)
                    .HasForeignKey(d => d.ImeiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductDistributor_IMEI");
            });

            modelBuilder.Entity<FactoryDelivery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FactoryDelivery");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.DeliveryDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeliveryStatus).HasMaxLength(50);

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.FactoryDeliveryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FactoryDelivery_Id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ReceiverName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Imei>(entity =>
            {
                entity.ToTable("IMEI");

                entity.Property(e => e.ImeiId).HasColumnName("IMEI_Id");

                entity.Property(e => e.ActivationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Activation_Date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(50)
                    .HasColumnName("Device_Type");

                entity.Property(e => e.ImeiNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMEI_Number");

                entity.Property(e => e.ImeiNumber2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMEI_Number_2");

                entity.Property(e => e.ImeiStatus)
                    .HasMaxLength(50)
                    .HasColumnName("IMEI_Status");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Imeis)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IMEI_Product");
            });

            modelBuilder.Entity<InboundOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InboundOrder");

                entity.Property(e => e.InboundDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Inbound_Date");

                entity.Property(e => e.InboundId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Inbound_id");

                entity.Property(e => e.InboundOrderId)
                    .HasMaxLength(50)
                    .HasColumnName("Inbound_OrderId");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Inventory");

                entity.Property(e => e.ActiveInventory).HasColumnName("Active_Inventory");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InActiveInventory).HasColumnName("InActive_Inventory");

                entity.Property(e => e.InventoryDuration).HasColumnName("Inventory_Duration");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Inventory_Id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.TotalInventory).HasColumnName("Total_Inventory");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.BillingAddress)
                    .HasMaxLength(150)
                    .HasColumnName("Billing_Address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(150)
                    .HasColumnName("Delivery_Address");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("Delivery_Date");

                entity.Property(e => e.DeliveryRecipient)
                    .HasMaxLength(50)
                    .HasColumnName("Delivery_Recipient");

                entity.Property(e => e.DeliveryStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Delivery_Status");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.OrderDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Description");

                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Status");

                entity.Property(e => e.OrderType)
                    .HasMaxLength(50)
                    .HasColumnName("Order_Type");

                entity.Property(e => e.SalePersonId).HasColumnName("SalePerson_Id");

                entity.Property(e => e.ShippingCharges).HasColumnName("Shipping_Charges");

                entity.Property(e => e.SubTotal).HasColumnName("Sub_Total");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.SalePerson)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalePersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_SalesPerson");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.PaymentAmount).HasColumnName("Payment_Amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Payment_Date");

                entity.Property(e => e.PaymentDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Payment_Description");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.DistributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Distributor");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MarketName).HasMaxLength(50);

                entity.Property(e => e.MaterialId).HasColumnName("Material_Id");

                entity.Property(e => e.Memory).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Code");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQuantity).HasColumnName("Product_Quantity");

                entity.Property(e => e.ProductSku)
                    .HasMaxLength(50)
                    .HasColumnName("Product_SKU");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductType_Id");

                entity.Property(e => e.Series).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductType1");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("ProductType");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductType_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProductWarehouse>(entity =>
            {
                entity.ToTable("Product_Warehouse");

                entity.Property(e => e.ProductWarehouseId).HasColumnName("ProductWarehouse_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WarehouseTypeId).HasColumnName("WarehouseType_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductWarehouses)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Warehouse_Product1");

                entity.HasOne(d => d.WarehouseType)
                    .WithMany(p => p.ProductWarehouses)
                    .HasForeignKey(d => d.WarehouseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Warehouse_Warehouse");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.PurchaseId);

                entity.ToTable("PurchaseOrder");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfDelivery).HasColumnType("datetime");

                entity.Property(e => e.DateOfOrder).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.PurchaseDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Purchase_Description");

                entity.Property(e => e.PurchaseName)
                    .HasMaxLength(50)
                    .HasColumnName("Purchase_Name");

                entity.Property(e => e.PurchaseQuantity)
                    .HasMaxLength(50)
                    .HasColumnName("Purchase_Quantity");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_Id");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrder_Vendor");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("PurchaseOrderDetail");

                entity.Property(e => e.PurchaseOrderDetailId).HasColumnName("PurchaseOrderDetail_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrderDetail_Product");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrderDetail_Purchase");
            });

            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.HasKey(e => e.OrderLineId)
                    .HasName("PK_OrderLine");

                entity.ToTable("PurchaseOrderLine");

                entity.Property(e => e.OrderLineId).HasColumnName("OrderLine_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderLineDescription)
                    .HasMaxLength(100)
                    .HasColumnName("OrderLine_Description");

                entity.Property(e => e.OrderLineQuantity).HasColumnName("OrderLine_Quantity");

                entity.Property(e => e.OrderLineUnitPrice).HasColumnName("OrderLine_UnitPrice");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_Id");

                entity.Property(e => e.TaxPercentage).HasColumnName("Tax_Percentage");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_Product1");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseOrderLines)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderLine_PurchaseOrder1");
            });

            modelBuilder.Entity<Receive>(entity =>
            {
                entity.ToTable("Receive");

                entity.Property(e => e.ReceiveId).HasColumnName("Receive_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ReceiptNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Receipt_Number");

                entity.Property(e => e.ReceiveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Receive_Date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Receives)
                    .HasForeignKey(d => d.DistributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receive_Distributor");
            });

            modelBuilder.Entity<Retailer>(entity =>
            {
                entity.ToTable("Retailer");

                entity.Property(e => e.RetailerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Retailer_id");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("Phone_number");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .HasColumnName("Postal_code");

                entity.Property(e => e.RetailerName)
                    .HasMaxLength(50)
                    .HasColumnName("Retailer_name");

                entity.Property(e => e.SalesRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Sales_region");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ReturnProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ReturnProduct");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DistributorId).HasColumnName("Distributor_Id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ReasonForReturn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ReturnDateTime).HasColumnType("datetime");

                entity.Property(e => e.ReturnId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Return_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasMaxLength(10)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.RoleDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Description");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("Role_Name");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SaleOrderLine>(entity =>
            {
                entity.HasKey(e => e.SalesOrderLineId);

                entity.ToTable("SaleOrderLine");

                entity.Property(e => e.SalesOrderLineId).HasColumnName("SalesOrderLine_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrder_Id");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrderLine_Product");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SaleOrderLines)
                    .HasForeignKey(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrderLine_SalesOrder");
            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.ToTable("SalesOrder");

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrder_Id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("Create_date");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShippingDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SalesOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailId)
                    .HasName("PK_OrderDetail");

                entity.ToTable("SalesOrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetail_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrder_Id");

                entity.Property(e => e.SalesRegion1).HasMaxLength(50);

                entity.Property(e => e.SalesRegion2).HasMaxLength(50);

                entity.Property(e => e.SalesRegion3).HasMaxLength(50);

                entity.Property(e => e.SalesRegion4).HasMaxLength(50);

                entity.Property(e => e.SalesRegion5).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.SalesOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.HasKey(e => e.SalePersonId);

                entity.ToTable("SalesPerson");

                entity.Property(e => e.SalePersonId).HasColumnName("SalePerson_Id");

                entity.Property(e => e.CommissionRate).HasColumnName("Commission_Rate");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.SalesRegion)
                    .HasMaxLength(50)
                    .HasColumnName("Sales_Region");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfile_Id");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(d => d.UserProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPerson_UserProfile");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(50)
                    .HasColumnName("Contact_No");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserLoginId).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword).HasColumnName("User_Password");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.UserProfileId).HasColumnName("UserProfile_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("First_Name");

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_User");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).HasColumnName("UserRole_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_User");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.Property(e => e.VendorId).HasColumnName("Vendor_Id");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPerson_Id");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VendorAddress)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_Address");

                entity.Property(e => e.VendorCity)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_City");

                entity.Property(e => e.VendorEmail)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_Email");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_Name");

                entity.Property(e => e.VendorPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_Phone");

                entity.Property(e => e.VendorPostalCode)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_PostalCode");

                entity.Property(e => e.VendorState)
                    .HasMaxLength(50)
                    .HasColumnName("Vendor_State");

                entity.HasOne(d => d.ContactPerson)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.ContactPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vendor_ContactPerson");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_Id");

                entity.Property(e => e.BranchId).HasColumnName("Branch_Id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("Updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_on")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WarehouseDescription)
                    .HasMaxLength(50)
                    .HasColumnName("Warehouse_Description");

                entity.Property(e => e.WarehouseName)
                    .HasMaxLength(50)
                    .HasColumnName("Warehouse_Name");

                entity.Property(e => e.WarehouseType)
                    .HasMaxLength(50)
                    .HasColumnName("Warehouse_Type");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse_Branch");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
