namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReservationModel3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reservations", "ReservationHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "ReservationHours", c => c.DateTime(nullable: false));
        }
    }
}
