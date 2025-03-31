using AutoMapperUsageInWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMapperUsageInWebAPI.Data
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        
        /*
        
        Migration commands
        
        PM> Add-Migration IntialMigratio
        PM> Update-Database
        PM> Remove-Migration
        PM> Update-Database -Migration: 0
        PM> Script-Migration
        PM> Script-Migration -Idempotent
        PM> Script-Migration -From 0 -To InitialMigration
        PM> Script-Migration -From 0 -To InitialMigration -Idempotent
        PM> Script-Migration -From 0 -To InitialMigration -Idempotent -OutputPath "C:\temp\migration.sql"
        
         */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This below data added for testing purpose not needed in real time
            modelBuilder.Entity<Product>().HasData(
                
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 1000,
                    SerialNumber = "ELE-DELL-Laptop-2025-001",
                    IsActive = true,
                    Brand = "DELL",
                    CategoryId = 1,
                    CreatedDateTime = new DateTime(2025,3,18,0,0,0,DateTimeKind.Utc),
                    Description = "Dell Laptop",
                    SupplierName = "MainITSupplier",
                    SupplierPrice = 900,
                    StockQuantity = 100,

                },
                 new Product
                 {
                     Id = 2,
                     Name = "Mobile",
                     Price = 500,
                     SerialNumber = "ELE-OnePlus-Mobile-2025-01",
                     IsActive = true,
                     Brand = "OnePlus",
                     CategoryId = 1,
                     CreatedDateTime = new DateTime(2025, 3, 18, 0, 0, 0, DateTimeKind.Utc),
                     Description = "OnePlus SmartPhone",
                     SupplierName = "MainITSupplier",
                     SupplierPrice = 300,
                     StockQuantity = 100,

                 }

                );
        }

         
    }
    
    
}
