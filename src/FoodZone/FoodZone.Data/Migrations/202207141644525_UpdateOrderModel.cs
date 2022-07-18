namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reservations", "ReservationHours", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "Hours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Hours", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "ReservationHours");
            DropColumn("dbo.Reservations", "ReservationDate");
        }
    }
}
