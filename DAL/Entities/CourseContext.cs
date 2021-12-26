using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class CourseContext : DbContext
    {
        public CourseContext()
            : base("name=CourseContext")
        {
        }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<MainCategory> MainCategory { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_String> Order_String { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<Supply_String> Supply_String { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Good)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.person_type)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Basket)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.specifications)
                .IsUnicode(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Basket)
                .WithRequired(e => e.Good1)
                .HasForeignKey(e => e.good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Order_String)
                .WithRequired(e => e.Good1)
                .HasForeignKey(e => e.good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Supply_String)
                .WithRequired(e => e.Good1)
                .HasForeignKey(e => e.good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.Category)
                .WithRequired(e => e.MainCategory)
                .HasForeignKey(e => e.main)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Manufacturer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Manufacturer>()
                .HasMany(e => e.Good)
                .WithRequired(e => e.Manufacturer1)
                .HasForeignKey(e => e.manufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_String)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.ord)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.account_number)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Supplier1)
                .HasForeignKey(e => e.supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Supply_String)
                .WithRequired(e => e.Supply1)
                .HasForeignKey(e => e.supply)
                .WillCascadeOnDelete(false);
        }
    }
}
