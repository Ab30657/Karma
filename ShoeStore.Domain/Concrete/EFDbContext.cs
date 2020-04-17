using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ShoeStore.Domain.Entities;

namespace ShoeStore.Domain.Concrete
{
    public partial class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=ShoeStore")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
        public virtual DbSet<CustomerPurchaseLog> CustomerPurchaseLogs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorPayment> VendorPayments { get; set; }
        public virtual DbSet<VendorPurchaseLog> VendorPurchaseLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerPayments)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerPurchaseLogs)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CustomerPayment>()
                .Property(e => e.GrandTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CustomerPurchaseLog>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CustomerPurchaseLog>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CustomerPurchaseLogs)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.VendorPurchaseLogs)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorPayments)
                .WithOptional(e => e.Vendor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorPurchaseLogs)
                .WithOptional(e => e.Vendor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<VendorPayment>()
                .Property(e => e.GrandTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorPayment>()
                .Property(e => e.Paid)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorPayment>()
                .Property(e => e.Due)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorPurchaseLog>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VendorPurchaseLog>()
                .Property(e => e.GrandTotal)
                .HasPrecision(18, 0);
        }
    }
}
