﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NTUPractice
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdventureWorks2017Entities : DbContext
    {
        public AdventureWorks2017Entities()
            : base("name=AdventureWorks2017Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.ProxyCreationEnabled = false;
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AWBuildVersion> AWBuildVersions { get; set; }
        public virtual DbSet<DatabaseLog> DatabaseLogs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<BusinessEntity> BusinessEntities { get; set; }
        public virtual DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public virtual DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CountryRegion> CountryRegions { get; set; }
        public virtual DbSet<EmailAddress> EmailAddresses { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonPhone> PersonPhones { get; set; }
        public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual DbSet<Culture> Cultures { get; set; }
        public virtual DbSet<Illustration> Illustrations { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCostHistory> ProductCostHistories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductInventory> ProductInventories { get; set; }
        public virtual DbSet<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelIllustration> ProductModelIllustrations { get; set; }
        public virtual DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhotoes { get; set; }
        public virtual DbSet<ProductProductPhoto> ProductProductPhotoes { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<ScrapReason> ScrapReasons { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
        public virtual DbSet<TransactionHistoryArchive> TransactionHistoryArchives { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderRouting> WorkOrderRoutings { get; set; }
        public virtual DbSet<ProductVendor> ProductVendors { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }
        public virtual DbSet<SalesPerson> SalesPersons { get; set; }
        public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }
        public virtual DbSet<SalesReason> SalesReasons { get; set; }
        public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }
        public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }
        public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }
        public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<ProductDocument> ProductDocuments { get; set; }
    }
}
