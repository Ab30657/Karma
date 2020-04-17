namespace ShoeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerPayment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        GrandTotal = c.Decimal(precision: 18, scale: 0),
                        Date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Image = c.Binary(maxLength: 50),
                        ImageMIMEType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomerPurchaseLog",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        ProductId = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 0),
                        Quantity = c.Int(),
                        Total = c.Decimal(precision: 18, scale: 0),
                        Date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Category = c.String(maxLength: 50),
                        Description = c.String(),
                        Price = c.Decimal(precision: 18, scale: 0),
                        Quantity = c.Int(),
                        Image = c.Binary(maxLength: 50),
                        ImageMIMEType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.VendorPurchaseLog",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(),
                        ProductId = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 0),
                        Quantity = c.Int(),
                        GrandTotal = c.Decimal(precision: 18, scale: 0),
                        Date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Vendor", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.VendorId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        LogoFileLocation = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.VendorId);
            
            CreateTable(
                "dbo.VendorPayment",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(),
                        GrandTotal = c.Decimal(precision: 18, scale: 0),
                        Paid = c.Decimal(precision: 18, scale: 0),
                        Due = c.Decimal(precision: 18, scale: 0),
                        Date = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Vendor", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerPurchaseLog", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.VendorPurchaseLog", "ProductId", "dbo.Product");
            DropForeignKey("dbo.VendorPurchaseLog", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.VendorPayment", "VendorId", "dbo.Vendor");
            DropForeignKey("dbo.CustomerPurchaseLog", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CustomerPayment", "CustomerId", "dbo.Customer");
            DropIndex("dbo.VendorPayment", new[] { "VendorId" });
            DropIndex("dbo.VendorPurchaseLog", new[] { "ProductId" });
            DropIndex("dbo.VendorPurchaseLog", new[] { "VendorId" });
            DropIndex("dbo.CustomerPurchaseLog", new[] { "ProductId" });
            DropIndex("dbo.CustomerPurchaseLog", new[] { "CustomerId" });
            DropIndex("dbo.CustomerPayment", new[] { "CustomerId" });
            DropTable("dbo.VendorPayment");
            DropTable("dbo.Vendor");
            DropTable("dbo.VendorPurchaseLog");
            DropTable("dbo.Product");
            DropTable("dbo.CustomerPurchaseLog");
            DropTable("dbo.Customer");
            DropTable("dbo.CustomerPayment");
        }
    }
}
