namespace ShoeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cat_SubCat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Product", "SubCategoryId", c => c.Int());
            AddColumn("dbo.Product", "CategoryId", c => c.Int());
            CreateIndex("dbo.Product", "SubCategoryId");
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "SubCategoryId", "dbo.SubCategory", "SubCategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SubCategory", c => c.String(maxLength: 50));
            AddColumn("dbo.Product", "Category", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Product", "SubCategoryId", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "CategoryId", "dbo.Category");
            DropIndex("dbo.SubCategory", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Product", new[] { "SubCategoryId" });
            DropColumn("dbo.Product", "CategoryId");
            DropColumn("dbo.Product", "SubCategoryId");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Category");
        }
    }
}
