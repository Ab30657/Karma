namespace ShoeStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcategoryaddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "SubCategory", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "SubCategory");
        }
    }
}
