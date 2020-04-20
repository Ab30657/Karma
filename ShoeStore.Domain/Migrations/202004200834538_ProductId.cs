namespace ShoeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            AlterColumn("dbo.SubCategory", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategory", "CategoryId");
            AddForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            AlterColumn("dbo.SubCategory", "CategoryId", c => c.Int());
            CreateIndex("dbo.SubCategory", "CategoryId");
            AddForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
