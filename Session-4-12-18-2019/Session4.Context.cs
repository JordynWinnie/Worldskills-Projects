﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session_4_12_18_2019
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Session4Entities : DbContext
    {
        public Session4Entities()
            : base("name=Session4Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
    }
}
