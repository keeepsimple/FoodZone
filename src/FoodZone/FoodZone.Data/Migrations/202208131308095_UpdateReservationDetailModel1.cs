namespace FoodZone.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReservationDetailModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods");
            DropIndex("dbo.ReservationDetails", new[] { "FoodId" });
            DropColumn("dbo.ReservationDetails", "FoodId");
            DropColumn("dbo.ReservationDetails", "FoodPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationDetails", "FoodPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.ReservationDetails", "FoodId", c => c.Int());
            CreateIndex("dbo.ReservationDetails", "FoodId");
            AddForeignKey("dbo.ReservationDetails", "FoodId", "dbo.Foods", "Id");
        }
    }
}
