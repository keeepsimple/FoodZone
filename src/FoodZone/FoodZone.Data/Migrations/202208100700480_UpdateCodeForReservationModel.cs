namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCodeForReservationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Code");
        }
    }
}
