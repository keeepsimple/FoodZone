namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyReservationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Capacity", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Adult");
            DropColumn("dbo.Reservations", "Child");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Child", c => c.Int(nullable: false));
            AddColumn("dbo.Reservations", "Adult", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Capacity");
        }
    }
}
