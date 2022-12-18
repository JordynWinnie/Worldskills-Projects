using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSC2019Kazan_S6_05272022_Windows
{
    public partial class Session6Context : DbContext
    {
        public Session6Context()
        {
        }

        public Session6Context(DbContextOptions<Session6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentLocation> DepartmentLocations { get; set; } = null!;
        public virtual DbSet<EmergencyMaintenance> EmergencyMaintenances { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=JORDY-DESKTOP\\SQLEXPRESS;user=sa;password=1234567890;database=Session6");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroupID");

                entity.Property(e => e.AssetName).HasMaxLength(150);

                entity.Property(e => e.AssetSn)
                    .HasMaxLength(20)
                    .HasColumnName("AssetSN");

                entity.Property(e => e.DepartmentLocationId).HasColumnName("DepartmentLocationID");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.WarrantyDate).HasColumnType("date");

                entity.HasOne(d => d.DepartmentLocation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.DepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_DepartmentLocations");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DepartmentLocation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Departments");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Locations");
            });

            modelBuilder.Entity<EmergencyMaintenance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.DescriptionEmergency).HasMaxLength(200);

                entity.Property(e => e.EmendDate)
                    .HasColumnType("date")
                    .HasColumnName("EMEndDate");

                entity.Property(e => e.EmrequestDate)
                    .HasColumnType("date")
                    .HasColumnName("EMRequestDate");

                entity.Property(e => e.EmstartDate)
                    .HasColumnType("date")
                    .HasColumnName("EMStartDate");

                entity.Property(e => e.EmtechnicianNote)
                    .HasMaxLength(200)
                    .HasColumnName("EMTechnicianNote");

                entity.Property(e => e.OtherConsiderations).HasMaxLength(200);

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.EmergencyMaintenances)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmergencyMaintenances_Assets");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DestinationWarehouseId).HasColumnName("DestinationWarehouseID");

                entity.Property(e => e.EmergencyMaintenancesId).HasColumnName("EmergencyMaintenancesID");

                entity.Property(e => e.SourceWarehouseId).HasColumnName("SourceWarehouseID");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.HasOne(d => d.DestinationWarehouse)
                    .WithMany(p => p.OrderDestinationWarehouses)
                    .HasForeignKey(d => d.DestinationWarehouseId)
                    .HasConstraintName("FK_Headers_Stocks1");

                entity.HasOne(d => d.EmergencyMaintenances)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmergencyMaintenancesId)
                    .HasConstraintName("FK_Headers_EmergencyMaintenances");

                entity.HasOne(d => d.SourceWarehouse)
                    .WithMany(p => p.OrderSourceWarehouses)
                    .HasForeignKey(d => d.SourceWarehouseId)
                    .HasConstraintName("FK_Headers_Stocks");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Headers_Suppliers");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Headers_TransactionTypes");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BatchNumber).HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Stock).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_Parts");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MinimumQuantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
