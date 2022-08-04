namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePropertiesFromModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Menus", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.News", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Reservations", "Note", c => c.String(maxLength: 500));
            AlterColumn("dbo.Reservations", "CancelReason", c => c.String(maxLength: 500));
            AlterColumn("dbo.Vouchers", "Title", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Foods", "Description");
            DropColumn("dbo.Reservations", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Foods", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Vouchers", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "CancelReason", c => c.String());
            AlterColumn("dbo.Reservations", "Note", c => c.String());
            AlterColumn("dbo.Reservations", "Name", c => c.String());
            AlterColumn("dbo.Reservations", "PhoneNumber", c => c.String());
            AlterColumn("dbo.News", "Image", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Menus", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Categories", "Name", c => c.String());
            DropColumn("dbo.Categories", "Image");
        }
    }
}
