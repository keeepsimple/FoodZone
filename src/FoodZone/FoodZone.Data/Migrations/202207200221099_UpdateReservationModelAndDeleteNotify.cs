namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReservationModelAndDeleteNotify : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifies", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Notifies", "UserId", "dbo.Users");
            DropIndex("dbo.Notifies", new[] { "UserId" });
            DropIndex("dbo.Notifies", new[] { "ReservationId" });
            AddColumn("dbo.Reservations", "CancelReason", c => c.String());
            DropTable("dbo.Notifies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Notifies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ReservationId = c.Int(nullable: false),
                        Content = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        InsertedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Reservations", "CancelReason");
            CreateIndex("dbo.Notifies", "ReservationId");
            CreateIndex("dbo.Notifies", "UserId");
            AddForeignKey("dbo.Notifies", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Notifies", "ReservationId", "dbo.Reservations", "Id", cascadeDelete: true);
        }
    }
}
