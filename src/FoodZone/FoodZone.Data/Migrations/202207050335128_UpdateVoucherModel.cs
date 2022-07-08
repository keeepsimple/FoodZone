namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVoucherModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Vouchers", "ExpiredDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vouchers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "Status");
            DropColumn("dbo.Vouchers", "ExpiredDate");
            DropColumn("dbo.Vouchers", "Title");
        }
    }
}
