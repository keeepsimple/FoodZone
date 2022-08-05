namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsHaveImage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Image", c => c.String());
            AlterColumn("dbo.News", "Image", c => c.String());
            AlterColumn("dbo.Vouchers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vouchers", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.News", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Image", c => c.String(nullable: false));
        }
    }
}
