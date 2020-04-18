﻿namespace ShoeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nike : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Product", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Quantity", c => c.Int());
            AlterColumn("dbo.Product", "Price", c => c.Decimal(precision: 18, scale: 0));
        }
    }
}
