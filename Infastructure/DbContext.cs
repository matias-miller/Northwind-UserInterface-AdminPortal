using Infrastructure.Models;

namespace Infrastructure;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{

    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Territory> Territories { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=northwind.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.Property(e => e.CategoryID)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255);
        });
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.Property(e => e.CategoryID)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255);
        });
        
        modelBuilder.Entity<CustomerDemographic>(entity =>
        {
            entity.ToTable("CustomerDemographics");
            entity.HasKey(e => e.CustomerTypeID);
            entity.Property(e => e.CustomerTypeID)
                .IsRequired();
            entity.Property(e => e.CustomerDesc)
                .HasMaxLength(255);
        });
        
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employees");
            entity.HasKey(e => e.EmployeeID);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Title)
                .HasMaxLength(50);
            entity.Property(e => e.TitleOfCourtesy)
                .HasMaxLength(50);
            entity.Property(e => e.BirthDate)
                .HasColumnType("date");
            entity.Property(e => e.HireDate)
                .HasColumnType("date");
            entity.Property(e => e.Address)
                .HasMaxLength(100);
            entity.Property(e => e.City)
                .HasMaxLength(50);
            entity.Property(e => e.Region)
                .HasMaxLength(50);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20);
            entity.Property(e => e.Country)
                .HasMaxLength(50);
            entity.Property(e => e.HomePhone)
                .HasMaxLength(20);
            entity.Property(e => e.Extension)
                .HasMaxLength(10);
            entity.Property(e => e.Notes)
                .IsRequired(false);
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(255);
        });
        
        modelBuilder.Entity<EmployeeTerritory>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeID, e.TerritoryID });
            entity.Property(e => e.EmployeeID)
                .IsRequired();
            entity.Property(e => e.TerritoryID)
                .IsRequired()
                .HasMaxLength(20);
        });
        
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Orders");
            entity.HasKey(e => e.OrderID);
            entity.Property(e => e.OrderID)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.CustomerID)
                .IsRequired(false);
            entity.Property(e => e.EmployeeID)
                .IsRequired(false);
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime");
            entity.Property(e => e.RequiredDate)
                .HasColumnType("datetime");
            entity.Property(e => e.ShippedDate)
                .HasColumnType("datetime");
            entity.Property(e => e.ShipVia)
                .IsRequired(false);
            entity.Property(e => e.Freight)
                .HasColumnType("numeric")
                .HasDefaultValue(0);
            entity.Property(e => e.ShipName)
                .IsRequired(false);
            entity.Property(e => e.ShipAddress)
                .IsRequired(false);
            entity.Property(e => e.ShipCity)
                .IsRequired(false);
            entity.Property(e => e.ShipRegion)
                .IsRequired(false);
            entity.Property(e => e.ShipPostalCode)
                .IsRequired(false);
            entity.Property(e => e.ShipCountry)
                .IsRequired(false);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetails");
            entity.HasKey(e => new { e.OrderID, e.ProductID });
            entity.Property(e => e.OrderID)
                .IsRequired();
            entity.Property(e => e.ProductID)
                .IsRequired();
            entity.Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("numeric");
            entity.Property(e => e.Quantity)
                .IsRequired()
                .HasDefaultValue(1);
            entity.Property(e => e.Discount)
                .IsRequired()
                .HasColumnType("real")
                .HasDefaultValue(0.0f);

            entity.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.ProductID);
            entity.Property(e => e.ProductID)
                .IsRequired();
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.SupplierID)
                .IsRequired(false);
            entity.Property(e => e.CategoryID)
                .IsRequired(false);
            entity.Property(e => e.QuantityPerUnit)
                .IsRequired(false);
            entity.Property(e => e.UnitPrice)
                .HasColumnType("numeric")
                .HasDefaultValue(0);
            entity.Property(e => e.UnitsInStock)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.UnitsOnOrder)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.ReorderLevel)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.Discontinued)
                .IsRequired()
                .HasDefaultValue("0");

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.ProductID);
            entity.Property(e => e.ProductID)
                .IsRequired();
            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.SupplierID)
                .IsRequired(false);
            entity.Property(e => e.CategoryID)
                .IsRequired(false);
            entity.Property(e => e.QuantityPerUnit)
                .IsRequired(false);
            entity.Property(e => e.UnitPrice)
                .HasColumnType("numeric")
                .HasDefaultValue(0);
            entity.Property(e => e.UnitsInStock)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.UnitsOnOrder)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.ReorderLevel)
                .IsRequired()
                .HasDefaultValue(0);
            entity.Property(e => e.Discontinued)
                .IsRequired()
                .HasDefaultValue("0");

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Regions");
            entity.HasKey(e => e.RegionID);
            entity.Property(e => e.RegionID)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.RegionDescription)
                .IsRequired()
                .HasMaxLength(255);
        });
        
        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.ToTable("Shippers");
            entity.HasKey(e => e.ShipperID);
            entity.Property(e => e.ShipperID)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(24);
        });
        
        modelBuilder.Entity<Territory>(entity =>
        {
            entity.ToTable("Territories");
            entity.HasKey(e => e.TerritoryID);
            entity.Property(e => e.TerritoryID)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.TerritoryDescription)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.RegionID)
                .IsRequired();
        });
    }
}