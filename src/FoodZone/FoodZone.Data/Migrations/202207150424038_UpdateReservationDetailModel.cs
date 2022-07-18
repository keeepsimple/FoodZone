namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReservationDetailModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods");
            DropIndex("dbo.ReservationDetails", new[] { "FoodId" });
            AlterColumn("dbo.ReservationDetails", "FoodId", c => c.Int());
            CreateIndex("dbo.ReservationDetails", "FoodId");
            AddForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods");
            DropIndex("dbo.ReservationDetails", new[] { "FoodId" });
            AlterColumn("dbo.ReservationDetails", "FoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReservationDetails", "FoodId");
            AddForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
        }
    }
}
