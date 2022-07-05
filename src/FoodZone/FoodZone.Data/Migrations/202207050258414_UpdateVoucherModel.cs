namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVoucherModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "Title");
        }
    }
}
