namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Stock = c.Int(nullable: false),
                        MinimumStock = c.Int(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastPurchaseDate = c.DateTime(),
                        Barcode = c.String(maxLength: 50),
                        Brand = c.String(maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ShippingId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Shippings", t => t.ShippingId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SupplierId)
                .Index(t => t.ShippingId);
            
            CreateTable(
                "dbo.Shippings",
                c => new
                    {
                        ShippingId = c.Int(nullable: false, identity: true),
                        CargoCompany = c.String(nullable: false, maxLength: 50),
                        TrackingNumber = c.String(nullable: false, maxLength: 50),
                        ShippingAddress = c.String(nullable: false, maxLength: 200),
                        ShipmentDate = c.DateTime(nullable: false),
                        ArriveDate = c.DateTime(),
                        ReceiverName = c.String(nullable: false, maxLength: 100),
                        ReceiverPhone = c.String(nullable: false, maxLength: 20),
                        Status = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ShippingId);
            
            CreateTable(
                "dbo.StockMovements",
                c => new
                    {
                        StockMovementId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        MovementType = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                        MovementDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 500),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockMovementId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                        Mail = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Nation = c.String(maxLength: 50),
                        Task = c.String(nullable: false, maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        ContactName = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.StockMovements", "ProductId", "dbo.Products");
            DropForeignKey("dbo.StockMovements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Products", "ShippingId", "dbo.Shippings");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.StockMovements", new[] { "EmployeeId" });
            DropIndex("dbo.StockMovements", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ShippingId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Employees");
            DropTable("dbo.StockMovements");
            DropTable("dbo.Shippings");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
